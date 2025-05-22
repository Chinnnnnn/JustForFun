using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Tools.CSV;

namespace Tools
{
    public class Excel
    {
        private static string _path = "";
        public static IWorkbook _wb = null;
        public static ISheet _sheet = null;

        public Excel(string path, bool create = false)
        {
            _path = path;
            if (create)
            {
                _path = path;
                _wb = new XSSFWorkbook();
            }
            else
            {
                using (FileStream file = new FileStream(_path, FileMode.Open, FileAccess.Read))
                {
                    _wb = new XSSFWorkbook(file);
                    file.Close();
                }
            }
        }

        public IWorkbook GetWorkbook() { return _wb; }

        public string Save(bool isNew = false)
        {
            if (isNew)
            {
                FileInfo fi = new FileInfo(_path);
                _path = $"{fi.Directory}{fi.Name}_{DateTime.Now.Ticks}{fi.Extension}";
            }

            using (FileStream file = new FileStream(_path, File.Exists(_path) ? FileMode.Create : FileMode.CreateNew, FileAccess.Write))
            {
                _wb.Write(file);
                file.Close();
            }

            return _path;
        }

        public void SetSheet(string name = "", int idx = -1)
        {
            if (string.IsNullOrWhiteSpace(name) && idx < 0)
                throw new Exception("Sheet name was not assigned!");

            if (!string.IsNullOrWhiteSpace(name))
            {
                _sheet = _wb.GetSheet(name);
                if (_sheet == null)
                    _sheet = _wb.CreateSheet(name);
            }
            else if (idx >= 0)
            {
                _sheet = _wb.GetSheetAt(idx);
                if (_sheet == null)
                    _sheet = _wb.CreateSheet("New Sheet");
            }
        }

        public int GetColIdx(string charc)
        {
            if (string.IsNullOrEmpty(charc)) return 0;
            int res = 0;
            for (int i = charc.Length - 1, j = 1; i >= 0; i--, j *= 26)
            {
                char c = Char.ToUpper(charc[i]);
                if (c < 'A' || c > 'Z') return 0;
                res += ((int)c - 64) * j;
            }

            return res;
        }

        public static string GetColCode(int idx)
        {
            string res = string.Empty;
            while (idx > 0)
            {
                int m = idx % 26;
                if (m == 0) m = 26;
                res = (char)(m + 64) + res;
                idx = (idx - m) / 26;
            }
            return res;
        }

        public List<T> GetList<T>(List<TransEle> mappings, ISheet sheet = null, int start = 0) where T : class, new()
        {
            var res = new List<T>();
            if (sheet == null && _sheet == null)
                return res;

            ISheet curSheet = sheet != null ? sheet : _sheet;

            var avails = new List<TransEle>();
            foreach (var ele in mappings)
            {
                if (ele.Idx < 0 && string.IsNullOrWhiteSpace(ele.Name))
                    continue;
                else if (ele.Idx >= 0 && string.IsNullOrWhiteSpace(ele.Name))
                    ele.Name = GetColCode(ele.Idx + 1);
                else if (ele.Idx < 0 && !string.IsNullOrEmpty(ele.Name))
                    ele.Idx = GetColIdx(ele.Code) - 1;

                avails.Add(ele);
            }

            for (int rowIdx = start; rowIdx <= curSheet.LastRowNum; rowIdx++)
            {
                var curRow = curSheet.GetRow(rowIdx);
                var cur = new T();
                ICell curCell = null;
                TransEle curEle = null;
                if (curRow.GetCell(mappings.Min(x => x.Idx)) == null)
                    continue;

                foreach (var ele in cur.GetType().GetProperties())
                {
                    curEle = avails.SingleOrDefault(x => x.Name == ele.Name);
                    if (curEle == null)
                        continue;

                    curCell = curRow.GetCell(curEle.Idx);
                    var val = GetCellValue(curCell);
                    ele.SetValue(cur, SetEleValue(val, ele.PropertyType));
                }

                if (cur == new T())
                    continue;

                res.Add(cur);
            }

            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="sheet"></param>
        /// <param name="start">If headers not null, start + 1</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public Enums.Result SetValue<T>(IList<T> source, List<TransEle> mappings, ISheet sheet = null, int start = 0, string[] headers = null, bool defaultCS = true, ICellStyle hdCS = null) where T : class
        {
            if (sheet == null && _sheet == null)
                sheet = _wb.CreateSheet($"Current_{DateTime.Now.ToString("yyMMdd HH:mm")}");

            ISheet curSheet = sheet != null ? sheet : _sheet;

            var avails = new List<TransEle>();
            foreach (var ele in mappings)
            {
                if (ele.Idx < 0 && string.IsNullOrWhiteSpace(ele.Name))
                    continue;
                else if (ele.Idx >= 0 && string.IsNullOrWhiteSpace(ele.Name))
                    ele.Name = GetColCode(ele.Idx + 1);
                else if (ele.Idx < 0 && !string.IsNullOrEmpty(ele.Name))
                    ele.Idx = GetColIdx(ele.Code) - 1;

                avails.Add(ele);
            }

            IRow curRow = null;
            ICell curCell = null;

            if (defaultCS)
                SetDefaultCSs();

            var rowIdx = start;
            if (headers != null)
            {
                //if (headers.Count() != avails.Count)
                //    return Enums.Result.Halt;
                curRow = curSheet.CreateRow(rowIdx);
                var idx = 0;
                foreach (var header in headers)
                {
                    curCell = curRow.CreateCell(idx);
                    curCell.SetCellValue(header);
                    if (defaultCS) curCell.CellStyle = _dfcsHeader;
                    idx++;
                }
                rowIdx++;
            }

            foreach (var each in source)
            {
                curRow = curSheet.CreateRow(rowIdx);
                TransEle curEle = null;
                foreach (var ele in each.GetType().GetProperties())
                {
                    curEle = avails.SingleOrDefault(x => x.Name == ele.Name);
                    if (curEle == null)
                        continue;

                    curCell = curRow.CreateCell(curEle.Idx);
                    SetCellValue(ref curCell, ele.PropertyType, ele.GetValue(each), defaultCS, curEle.CellStyle);
                }
                rowIdx++;
            }


            foreach (var ele in curSheet.GetRow(curSheet.LastRowNum).Cells)
            {
                curSheet.AutoSizeColumn(ele.ColumnIndex);
            }

            return Enums.Result.Success;
        }

        public void SetCellValue(ref ICell cell, Type type, object raw, bool dfCS = false, ICellStyle curCS = null)
        {
            if (new[] { typeof(Int32), typeof(Int64), typeof(Int16), typeof(Nullable<Int32>), typeof(Nullable<Int64>), typeof(Nullable<Int16>) }.Contains(type))
            {
                var num = 0;
                int.TryParse(raw.ToString(), out num);
                cell.SetCellType(CellType.Numeric);
                if (dfCS) cell.CellStyle = _dfcsNum;
                else if (!dfCS && curCS != null) cell.CellStyle = curCS;
                cell.SetCellValue(num);
            }
            else if (new[] { typeof(double), typeof(Nullable<double>), typeof(decimal), typeof(Nullable<decimal>), typeof(float), typeof(Nullable<float>) }.Contains(type))
            {
                double dob = 0;
                double.TryParse(raw.ToString(), out dob);
                cell.SetCellType(CellType.Numeric);
                if (dfCS) cell.CellStyle = _dfcsNum;
                else if (!dfCS && curCS != null) cell.CellStyle = curCS;
                cell.SetCellValue(dob);
            }
            else if (new[] { typeof(DateTime), typeof(Nullable<DateTime>) }.Contains(type))
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(raw.ToString(), out dt);
                if (dfCS) cell.CellStyle = _dfcsDateTime;
                else if (!dfCS && curCS != null) cell.CellStyle = curCS;
                cell.SetCellValue(dt.ToString("yyyy-MM-dd HH:mm"));
            }
            else
            {
                if (dfCS) cell.CellStyle = _dfcsString;
                else if (!dfCS && curCS != null) cell.CellStyle = curCS;
                cell.SetCellValue(raw.ToString());
            }
        }

        public static object GetCellValue(ICell cell)
        {
            switch (cell.CellType)
            {
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Numeric:
                    if (DateUtil.IsCellDateFormatted(cell))
                    {
                        DateTime date = cell.DateCellValue.Value;
                        ICellStyle style = cell.CellStyle;
                        string format = style.GetDataFormatString().Replace('m', 'M');
                        return date.ToString(format);
                    }
                    else if (cell.CellStyle.DataFormat >= 164 && DateUtil.IsValidExcelDate(cell.NumericCellValue) && cell.DateCellValue != null)
                        return cell.DateCellValue.Value;
                    else
                        return cell.NumericCellValue.ToString();
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Formula:
                    return cell.StringCellValue;
                case CellType.Unknown:
                default:
                    return cell.StringCellValue;
            }
        }

        public static object SetEleValue(object raw, Type type)
        {
            if (new[] { typeof(Int32), typeof(Int64), typeof(Int16), typeof(Nullable<Int32>), typeof(Nullable<Int64>), typeof(Nullable<Int16>) }.Contains(type))
            {
                var num = 0;
                int.TryParse(raw.ToString(), out num);
                return num;
            }
            else if (new[] { typeof(decimal), typeof(Nullable<decimal>) }.Contains(type))
            {
                decimal dec = 0;
                decimal.TryParse(raw.ToString(), out dec);
                return dec;
            }
            else if (new[] { typeof(double), typeof(Nullable<double>) }.Contains(type))
            {
                double dob = 0;
                double.TryParse(raw.ToString(), out dob);
                return dob;
            }
            else if (new[] { typeof(float), typeof(Nullable<float>) }.Contains(type))
            {
                float flo = 0;
                float.TryParse(raw.ToString(), out flo);
                return flo;
            }
            else if (new[] { typeof(DateTime), typeof(Nullable<DateTime>) }.Contains(type))
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(raw.ToString(), out dt);
                return dt;
            }
            else
                return raw?.ToString() ?? "";
        }
        public class TransEle
        {
            public int Idx { get; set; } = -1;
            public string Code { get; set; } = null!;
            public string Name { get; set; } = null!;
            public ICellStyle? CellStyle { get; set; } = null;
        }

        #region Cell Styles
        static ICellStyle _dfcsString = null!;
        static ICellStyle _dfcsNum = null!;
        static ICellStyle _dfcsDateTime = null!;
        static ICellStyle _dfcsHeader = null!;

        #endregion Cell Styles
        public void SetDefaultCSs()
        {
            #region Header
            _dfcsHeader = _wb.CreateCellStyle();
            _dfcsHeader.BorderTop = BorderStyle.Thin;
            _dfcsHeader.TopBorderColor = HSSFColor.Black.Index;
            _dfcsHeader.BorderRight = BorderStyle.Thin;
            _dfcsHeader.RightBorderColor = HSSFColor.Black.Index;
            _dfcsHeader.BorderBottom = BorderStyle.Thin;
            _dfcsHeader.BottomBorderColor = HSSFColor.Black.Index;
            _dfcsHeader.BorderLeft = BorderStyle.Thin;
            _dfcsHeader.LeftBorderColor = HSSFColor.Black.Index;

            _dfcsHeader.FillPattern = FillPattern.SolidForeground;
            _dfcsHeader.FillForegroundColor = HSSFColor.LightBlue.Index;
            IFont hFont = _wb.CreateFont();
            hFont.FontName = "微軟正黑體";
            hFont.IsBold = true;
            hFont.Color = HSSFColor.White.Index;
            _dfcsHeader.SetFont(hFont);
            #endregion Header
            #region Row
            #region String
            _dfcsString = _wb.CreateCellStyle();
            _dfcsString.BorderTop = BorderStyle.Thin;
            _dfcsString.TopBorderColor = HSSFColor.Black.Index;
            _dfcsString.BorderRight = BorderStyle.Thin;
            _dfcsString.RightBorderColor = HSSFColor.Black.Index;
            _dfcsString.BorderBottom = BorderStyle.Thin;
            _dfcsString.BottomBorderColor = HSSFColor.Black.Index;
            _dfcsString.BorderLeft = BorderStyle.Thin;
            _dfcsString.LeftBorderColor = HSSFColor.Black.Index;
            #endregion String
            IFont rFont = _wb.CreateFont();
            rFont.FontName = "微軟正黑體";
            rFont.IsBold = false;
            rFont.Color = HSSFColor.Black.Index;
            _dfcsString.SetFont(rFont);

            #region Number
            _dfcsNum = _wb.CreateCellStyle();
            _dfcsNum.BorderTop = BorderStyle.Thin;
            _dfcsNum.TopBorderColor = HSSFColor.Black.Index;
            _dfcsNum.BorderRight = BorderStyle.Thin;
            _dfcsNum.RightBorderColor = HSSFColor.Black.Index;
            _dfcsNum.BorderBottom = BorderStyle.Thin;
            _dfcsNum.BottomBorderColor = HSSFColor.Black.Index;
            _dfcsNum.BorderLeft = BorderStyle.Thin;
            _dfcsNum.LeftBorderColor = HSSFColor.Black.Index;

            _dfcsNum.DataFormat = HSSFDataFormat.GetBuiltinFormat("#.##");
            _dfcsNum.SetFont(rFont);
            #endregion Number
            #region Datetime
            _dfcsDateTime = _wb.CreateCellStyle();
            _dfcsDateTime.BorderTop = BorderStyle.Thin;
            _dfcsDateTime.TopBorderColor = HSSFColor.Black.Index;
            _dfcsDateTime.BorderRight = BorderStyle.Thin;
            _dfcsDateTime.RightBorderColor = HSSFColor.Black.Index;
            _dfcsDateTime.BorderBottom = BorderStyle.Thin;
            _dfcsDateTime.BottomBorderColor = HSSFColor.Black.Index;
            _dfcsDateTime.BorderLeft = BorderStyle.Thin;
            _dfcsDateTime.LeftBorderColor = HSSFColor.Black.Index;

            _dfcsDateTime.DataFormat = HSSFDataFormat.GetBuiltinFormat("yyyy-MM-dd HH:mm");
            _dfcsDateTime.SetFont(rFont);
            #endregion Datetime
            #endregion Row
        }
    }
}
