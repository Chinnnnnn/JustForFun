/*
 Navicat Premium Dump SQL

 Source Server         : OwnDev
 Source Server Type    : MySQL
 Source Server Version : 90001 (9.0.1)
 Source Host           : localhost:3306
 Source Schema         : owndev

 Target Server Type    : MySQL
 Target Server Version : 90001 (9.0.1)
 File Encoding         : 65001

 Date: 22/05/2025 11:59:11
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for hexagrams
-- ----------------------------
DROP TABLE IF EXISTS `hexagrams`;
CREATE TABLE `hexagrams`  (
  `NumKey` char(6) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `NameZh` varchar(4) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `AbbrZh` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `NameEn` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `AbbrEn` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `Sort` int NULL DEFAULT NULL,
  `Up` int NOT NULL DEFAULT -1 COMMENT '上爻',
  `Bottom` int NOT NULL DEFAULT -1 COMMENT '下爻',
  `MeaningZh` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `MeaningEn` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `DescZh` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL DEFAULT '',
  `DescEn` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`NumKey`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of hexagrams
-- ----------------------------
INSERT INTO `hexagrams` VALUES ('000000', '坤為地', '坤', '', 'kūn', 0, 0, 0, '象徵純陰，代表承載和順從。', NULL, '坤，元亨，利牝馬之貞。君子有攸往，先迷後得，主利，西南得朋，東北喪朋，安貞吉。', NULL);
INSERT INTO `hexagrams` VALUES ('000001', '地雷復', '復', '', 'fù', 1, 0, 4, '象徵回復，代表重新開始和復甦。', NULL, '復，亨。出入无疾，朋來无咎。反復其道，七日來復，利有攸往。', NULL);
INSERT INTO `hexagrams` VALUES ('000010', '地水師', '師', '', 'shī', 2, 0, 2, '代表軍隊，象徵組織和力量。', NULL, '師，丈人吉，无咎。', NULL);
INSERT INTO `hexagrams` VALUES ('000011', '地澤臨', '臨', '', 'lín', 3, 0, 6, '象徵臨視和關注，需監督和指導。', NULL, '臨，元亨利貞，至于八月有凶。', NULL);
INSERT INTO `hexagrams` VALUES ('000100', '地山謙', '謙', '', 'qiān', 4, 0, 1, '代表謙虛和謙遜，重視低調。', NULL, '謙，亨，君子有終。', NULL);
INSERT INTO `hexagrams` VALUES ('000101', '地火明夷', '明夷', '', 'míng yí', 5, 0, 5, '象徵隱晦，代表挫折和隱藏。', NULL, '明夷，利艱貞。', NULL);
INSERT INTO `hexagrams` VALUES ('000110', '地風升', '升', '', 'shēng', 6, 0, 3, '象徵上升，需提升和進步。', NULL, '升，元亨。用見大人，勿恤。南征吉。', NULL);
INSERT INTO `hexagrams` VALUES ('000111', '地天泰', '泰', '', 'tài', 7, 0, 7, '象徵通泰，代表順利和和諧。', NULL, '泰，小往大來，吉亨。', NULL);
INSERT INTO `hexagrams` VALUES ('001000', '雷地豫', '豫', '', 'yù', 8, 4, 0, '象徵喜悅，代表安樂和喜悅。', NULL, '豫，利建侯、行師。', NULL);
INSERT INTO `hexagrams` VALUES ('001001', '震為雷', '震', '', 'zhèn', 9, 4, 4, '象徵震動，代表驚動和啟示。', NULL, '震，亨。震來虩虩，笑言啞啞，震驚百里，不喪匕鬯。', NULL);
INSERT INTO `hexagrams` VALUES ('001010', '雷水解', '解', '', 'xiè', 10, 4, 2, '代表解脫，需解決和釋放。', NULL, '解，利西南，无所往，其來復吉；有攸往，夙吉。', NULL);
INSERT INTO `hexagrams` VALUES ('001011', '雷澤歸妹', '歸妹', '', 'guī mèi', 11, 4, 6, '象徵嫁娶，代表婚姻和聯合。', NULL, '歸妹，征凶，无攸利。', NULL);
INSERT INTO `hexagrams` VALUES ('001100', '雷山小過', '小過', '', 'xiǎo guò', 12, 4, 1, '代表小有過失，需謹慎和改正。', NULL, '小過，亨，利貞。可小事，不可大事。飛鳥遺之音，不宜上，宜下。大吉。', NULL);
INSERT INTO `hexagrams` VALUES ('001101', '雷火豐', '豐', '', 'fēng', 13, 4, 5, '代表豐富，需豐滿和充實。', NULL, '豐，亨，王假之，勿憂，宜日中。', NULL);
INSERT INTO `hexagrams` VALUES ('001110', '雷風恆', '恆', '', 'héng', 14, 4, 3, '象徵恆久，需持久和堅持。', NULL, '恆，亨，无咎，利貞，利有攸往。', NULL);
INSERT INTO `hexagrams` VALUES ('001111', '雷天大壯', '大壯', '', 'dà zhuàng', 15, 4, 7, '象徵壯大，代表強盛和壯大。', NULL, '大壯，利貞。', NULL);
INSERT INTO `hexagrams` VALUES ('010000', '水地比', '比', '', 'bǐ', 16, 2, 0, '象徵親近和團結，重視合作。', NULL, '比，原筮元永貞，无咎。不寧方來，後夫凶。', NULL);
INSERT INTO `hexagrams` VALUES ('010001', '水雷屯', '屯', '', 'zhūn', 17, 2, 4, '代表困難的開始，有艱難險阻。', NULL, '屯，元亨利貞，勿用有攸往，利建侯。', NULL);
INSERT INTO `hexagrams` VALUES ('010010', '坎為水', '坎', '', 'kǎn', 18, 2, 2, '象徵重重困難，需堅忍和克服。', NULL, '坎，有孚，維心亨，行有尚。', NULL);
INSERT INTO `hexagrams` VALUES ('010011', '水澤節', '節', '', 'jié', 19, 2, 6, '代表節制，需節約和規範。', NULL, '節，亨。苦節，不可貞。', NULL);
INSERT INTO `hexagrams` VALUES ('010100', '水山蹇', '蹇', '', 'jiǎn', 20, 2, 1, '象徵艱難，需克服和幫助。', NULL, '蹇，利西南，不利東北，利見大人，貞吉。', NULL);
INSERT INTO `hexagrams` VALUES ('010101', '水火既濟', '既濟', '', 'jì jì', 21, 2, 5, '象徵成功，代表成就和完成。', NULL, '既濟，亨小，利貞。初吉終亂。', NULL);
INSERT INTO `hexagrams` VALUES ('010110', '水風井', '井', '', 'jǐng', 22, 2, 3, '代表井然有序，需組織和管理。', NULL, '井，改邑不改井，无喪无得，往來井，井汔至，亦未繘井，羸其瓶，凶。', NULL);
INSERT INTO `hexagrams` VALUES ('010111', '水天需', '需', '', 'xū', 23, 2, 7, '代表等待時機，有忍耐和期望。', NULL, '需，有孚，光亨，貞吉，利涉大川。', NULL);
INSERT INTO `hexagrams` VALUES ('011000', '澤地萃', '萃', '', 'cuì', 24, 6, 0, '代表聚集，需集合和團聚。', NULL, '萃，亨，王假有廟，利見大人，亨，利貞。用大牲吉。利有攸往。', NULL);
INSERT INTO `hexagrams` VALUES ('011001', '澤雷隨', '隨', '', 'suí', 25, 6, 4, '象徵隨和，需順應和適應。', NULL, '隨，元亨利貞，无咎。', NULL);
INSERT INTO `hexagrams` VALUES ('011010', '澤水困', '困', '', 'kùn', 26, 6, 2, '象徵困境，需忍耐和克服。', NULL, '困，亨，貞大人吉，无咎。有言不信。', NULL);
INSERT INTO `hexagrams` VALUES ('011011', '兌為澤', '兌', '', 'duì', 27, 6, 6, '象徵喜悅，代表愉悅和歡樂。', NULL, '兌，亨，利貞。', NULL);
INSERT INTO `hexagrams` VALUES ('011100', '澤山咸', '咸', '', 'xián', 28, 6, 1, '象徵感應，代表感應和默契。', NULL, '咸，亨，利貞，取女吉。', NULL);
INSERT INTO `hexagrams` VALUES ('011101', '澤火革', '革', '', 'gé', 29, 6, 5, '象徵變革，代表改革和更新。', NULL, '革，已日乃孚，元亨利貞，悔亡。', NULL);
INSERT INTO `hexagrams` VALUES ('011110', '澤風大過', '大過', '', 'dà guò', 30, 6, 3, '代表過度，需中正和適度。', NULL, '大過，棟橈。利有攸往，亨。', NULL);
INSERT INTO `hexagrams` VALUES ('011111', '澤天夬', '夬', '', 'guài', 31, 6, 7, '象徵決斷，需果斷和決策。', NULL, '夬，揚于王庭，孚號有厲。告自邑，不利即戎，利有攸往。', NULL);
INSERT INTO `hexagrams` VALUES ('100000', '山地剝', '剝', '', 'bō', 32, 1, 0, '象徵剝落，代表衰敗和剝落。', NULL, '剝，不利有攸往。', NULL);
INSERT INTO `hexagrams` VALUES ('100001', '山雷頤', '頤', '', 'yí', 33, 1, 4, '象徵頤養，需保養和養生。', NULL, '頤，貞吉，觀頤，自求口實。', NULL);
INSERT INTO `hexagrams` VALUES ('100010', '山水蒙', '蒙', '', 'méng', 34, 1, 2, '象徵蒙昧，需教育和啟蒙。', NULL, '蒙，亨。匪我求童蒙，童蒙求我。初筮告，再三瀆，瀆則不告。利貞。', NULL);
INSERT INTO `hexagrams` VALUES ('100011', '山澤損', '損', '', 'sǔn', 35, 1, 6, '象徵減損，需減少和節制。', NULL, '損，有孚，元吉，无咎可貞，利有攸往。曷之用，二簋可用享。', NULL);
INSERT INTO `hexagrams` VALUES ('100100', '艮為山', '艮', '', 'gèn', 36, 1, 1, '象徵停止，需靜止和安定。', NULL, '艮，不獲其身；行其庭，不見其人。无咎。', NULL);
INSERT INTO `hexagrams` VALUES ('100101', '山火賁', '賁', '', 'bì', 37, 1, 5, '代表修飾和裝飾，需美化和修飾。', NULL, '賁，亨，小利有攸往。', NULL);
INSERT INTO `hexagrams` VALUES ('100110', '山風蠱', '蠱', '', 'gŭ', 38, 1, 3, '代表腐敗和修正，需改革和治理。', NULL, '蠱，元亨，利涉大川。先甲三日，後甲三日。', NULL);
INSERT INTO `hexagrams` VALUES ('100111', '山天大畜', '大畜', '', 'dà xù', 39, 1, 7, '代表大有積蓄，需積累和貯藏。', NULL, '大畜，利貞，不家食吉，利涉大川。', NULL);
INSERT INTO `hexagrams` VALUES ('101000', '火地晉', '晉', '', 'jìn', 40, 5, 0, '代表進步，需提升和進展。', NULL, '晉，康侯用錫馬蕃庶，晝日三接。', NULL);
INSERT INTO `hexagrams` VALUES ('101001', '火雷噬嗑', '噬嗑', '', 'shì kè', 41, 5, 4, '象徵口舌和刑罰，需公平和正義。', NULL, '噬嗑，亨，利用獄。', NULL);
INSERT INTO `hexagrams` VALUES ('101010', '火水未濟', '未濟', '', 'wèi jì', 42, 5, 2, '代表未完成，需繼續努力和追求。', NULL, '未濟，亨。小狐汔濟，濡其尾，无攸利。', NULL);
INSERT INTO `hexagrams` VALUES ('101011', '火澤睽', '睽', '', 'kuí', 43, 5, 6, '象徵離異，代表分離和對立。', NULL, '睽，小事吉。', NULL);
INSERT INTO `hexagrams` VALUES ('101100', '火山旅', '旅', '', 'lǚ', 44, 5, 1, '象徵旅程，需流動和漂泊。', NULL, '旅，小亨，旅貞吉。', NULL);
INSERT INTO `hexagrams` VALUES ('101101', '離為火', '離', '', 'lí', 45, 5, 5, '象徵光明和附著，代表智慧和光明。', NULL, '離，利貞，亨，畜牝牛，吉。', NULL);
INSERT INTO `hexagrams` VALUES ('101110', '火風鼎', '鼎', '', 'dǐng', 46, 5, 3, '象徵鼎盛，代表鼎盛和成熟。', NULL, '鼎，元吉亨。', NULL);
INSERT INTO `hexagrams` VALUES ('101111', '火天大有', '大有', '', 'dà yǒu', 47, 5, 7, '象徵大有收穫，代表富裕和成功。', NULL, '大有，元亨。', NULL);
INSERT INTO `hexagrams` VALUES ('110000', '風地觀', '觀', '', 'guān', 48, 3, 0, '象徵觀察，代表察看和省察。', NULL, '觀，盥而不薦，有孚顒若。', NULL);
INSERT INTO `hexagrams` VALUES ('110001', '風雷益', '益', '', 'yì', 49, 3, 4, '代表增加，需增益和助益。', NULL, '益，利有攸往，利涉大川。', NULL);
INSERT INTO `hexagrams` VALUES ('110010', '風水渙', '渙', '', 'huàn', 50, 3, 2, '象徵渙散，代表分散和消散。', NULL, '渙，亨，王假有廟，利涉大川，利貞。', NULL);
INSERT INTO `hexagrams` VALUES ('110011', '風澤中孚', '中孚', '', 'zhōng fú', 51, 3, 6, '象徵誠信，需信任和忠誠。', NULL, '中孚，豚魚吉，利涉大川，利貞。', NULL);
INSERT INTO `hexagrams` VALUES ('110100', '風山漸', '漸', '', 'jiàn', 52, 3, 1, '代表逐漸，需逐步和進展。', NULL, '漸，女歸吉，利貞。', NULL);
INSERT INTO `hexagrams` VALUES ('110101', '風火家人', '家人', '', 'jiā rén', 53, 3, 5, '代表家庭，需和睦和治理。', NULL, '家人，利女貞。', NULL);
INSERT INTO `hexagrams` VALUES ('110110', '巽為風', '巽', '', 'xùn', 54, 3, 3, '象徵順從，代表順從和通達。', NULL, '巽，小亨，利有攸往，利見大人。', NULL);
INSERT INTO `hexagrams` VALUES ('110111', '風天小畜', '小畜', '', 'xiǎo xù', 55, 3, 7, '代表小有積蓄，需謹慎和積累。', NULL, '小畜，亨。密雲不雨，自我西郊。', NULL);
INSERT INTO `hexagrams` VALUES ('111000', '天地否', '否', '', 'pǐ', 56, 7, 0, '象徵否閉，代表困頓和不通。', NULL, '否，不利君子貞，大往小來。', NULL);
INSERT INTO `hexagrams` VALUES ('111001', '天雷無妄', '无妄', '', 'wú wàng', 57, 7, 4, '象徵無妄，代表自然和純真。', NULL, '无妄，元亨利貞。其匪正有眚，不利有攸往。', NULL);
INSERT INTO `hexagrams` VALUES ('111010', '天水訟', '訟', '', 'sòng', 58, 7, 2, '象徵爭訟，需正義和解決爭端。', NULL, '訟，有孚窒惕，中吉終凶。利見大人，不利涉大川。', NULL);
INSERT INTO `hexagrams` VALUES ('111011', '天澤履', '履', '', 'lǚ', 59, 7, 6, '象徵步履和行動，需踏實和小心。', NULL, '履，不咥人，亨。', NULL);
INSERT INTO `hexagrams` VALUES ('111100', '天山遯', '遯', '', 'dùn', 60, 7, 1, '代表退避，需隱退和躲避。', NULL, '遯，亨，小利貞。', NULL);
INSERT INTO `hexagrams` VALUES ('111101', '天火同人', '同人', '', 'tóng rén', 61, 7, 5, '代表團結一致，需和諧共處。', NULL, '同人，亨。利涉大川，利君子貞。', NULL);
INSERT INTO `hexagrams` VALUES ('111110', '天風姤', '姤', '', 'gòu', 62, 7, 3, '象徵相遇，代表邂逅和相遇。', NULL, '姤，女壯，勿用取女。', NULL);
INSERT INTO `hexagrams` VALUES ('111111', '乾為天', '乾', '', 'qián', 63, 7, 7, '象徵純陽，代表創造和進取。', NULL, '乾，元亨利貞。', NULL);

SET FOREIGN_KEY_CHECKS = 1;
