using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using static Tools.CSV;

namespace Tools
{
    public class CSV
    {
        internal bool _valid = true;
        internal string _path = "";
        //for transfer
        public class T;
        public List<Mapping> _mappings = new List<Mapping>();
        public StringBuilder _errMsg = new StringBuilder();
        public CSV(string filePath)
        {
            if (!File.Exists(filePath))
            {
                _path = "";
                _valid = false;
                return;
            }

            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Extension.ToLower() != "csv")
            {
                _path = "";
                _valid = false;
                return;
            }

            _path = filePath;
        }

        public List<string> GetRawData()
        {
            var res = new List<string>();
            if (!Validate())
                return res;

            using (FileStream fs = new FileStream(_path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    var raw = sr.ReadToEnd();
                    var temps = raw.Split("\r\n");
                    for (int idx = 0; idx < temps.Length; idx++)
                    {
                        if (idx == 0)
                        {
                            if (temps[idx].Split(",").Length != _mappings.Count)
                                break;
                        }
                        else
                        {
                            var chk = temps[idx].Split(",");
                            if (chk.Any(x => !string.IsNullOrWhiteSpace(x)))
                                res.Add(temps[idx]);
                        }
                    }
                }
            }
            return res;
        }

        public void SetTransferInfo(List<Mapping> mappings)
        {
            if (mappings == null || mappings?.Count == 0)
            {
                _valid = false;
                return;
            }

            _mappings = mappings;
        }

        public bool Validate()
        {
            _valid = true;

            if (string.IsNullOrWhiteSpace(_path) || !File.Exists(_path))
                _valid = false;

            if (_mappings == null || _mappings?.Count == 0)
                _valid = false;

            return _valid;
        }

        public List<T> Transfer()
        {
            var res = new List<T>();

            var rawData = GetRawData();

            if (rawData == null)
                return res;

            _errMsg.Clear();

            foreach (var raw in rawData)
            {
                var temps = raw.Split(",");
                var cur = new T();
                var isOK = true;
                foreach (var propInfo in cur.GetType().GetProperties())
                {
                    var tar = _mappings.Single(x => x.Header == propInfo.Name);
                    if (tar == null)
                        continue;

                    var val = temps[tar.Idx];
                    var type = propInfo.PropertyType;

                    //parse type
                    try
                    {
                        switch (Type.GetTypeCode(type))
                        {
                            case TypeCode.Int32:
                            case TypeCode.Int64:
                            case TypeCode.Int16:
                                propInfo.SetValue(cur, int.Parse(val.ToString()));
                                break;
                            case TypeCode.Decimal:
                                propInfo.SetValue(cur, decimal.Parse(val.ToString()));
                                break;
                            case TypeCode.DateTime:
                                propInfo.SetValue(cur, DateTime.Parse(val.ToString()));
                                break;
                            default:
                                propInfo.SetValue(cur, val.ToString());
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        isOK = false;
                        _errMsg.AppendLine($"{raw}:{ex.Message.ToString()}");
                    }
                }

                if (isOK)
                    res.Add(cur);
            }

            return new List<T>();
        }

        public string GetErrMsgs()
        { return _errMsg.ToString(); }

        public class Mapping
        {
            public int Idx { get; set; }
            public string Header { get; set; }
            public string MatchName { get; set; }
        }

    }
}
