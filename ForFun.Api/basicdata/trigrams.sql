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

 Date: 22/05/2025 11:59:30
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for trigrams
-- ----------------------------
DROP TABLE IF EXISTS `trigrams`;
CREATE TABLE `trigrams`  (
  `NumKey` char(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL,
  `Num` int NULL DEFAULT NULL COMMENT '2進位換算10進位',
  `NameZh` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `NameEn` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL,
  `FigureU` int NULL DEFAULT NULL COMMENT '下爻',
  `FigureM` int NULL DEFAULT NULL COMMENT '中爻',
  `FigureL` int NULL DEFAULT NULL COMMENT '上爻',
  `NatureZh` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '自然象徵',
  `NatureEn` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '自然象徵',
  `DirEarlierZh` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '先天八卦方位',
  `DirEarlierEn` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '先天八卦方位',
  `DirLaterZh` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '後天八卦方位',
  `DirLaterEn` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '後天八卦方位',
  `FamilyZh` varchar(2) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '家族關係',
  `FamilyEn` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '家族關係',
  `AnimalZh` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '動物',
  `AnimalEn` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '動物',
  `PhaseZh` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '五行',
  `PhaseEn` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '五行',
  `BodyPartZh` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '身體部位',
  `BodyPartEn` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '身體部位',
  `OrganZh` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL DEFAULT NULL COMMENT '器官',
  `OrganEn` varchar(10) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL COMMENT '器官',
  PRIMARY KEY (`NumKey`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of trigrams
-- ----------------------------
INSERT INTO `trigrams` VALUES ('000', 0, '坤', 'kūn', 0, 0, 0, '地', 'earth', '南', 'north', '西南', 'southwest', '母親', 'mother', '牛', 'cow', '土', 'earth', '腹', 'belly', '脾', 'spleen');
INSERT INTO `trigrams` VALUES ('001', 4, '震', 'zhèn', 0, 0, 1, '雷', 'thunder', '東北', 'northeast', '東', 'east', '長男', 'first son', '龍', 'dragon', '木', 'wood', '足', 'foot', '肝', 'liver');
INSERT INTO `trigrams` VALUES ('010', 2, '坎', 'kǎn', 0, 1, 0, '水', 'water', '西', 'west', '南', 'north', '中男', 'second son', '豕', 'pig', '水', 'water', '耳', 'ear', '腎', 'kidney');
INSERT INTO `trigrams` VALUES ('011', 6, '兌', 'duì', 0, 1, 1, '澤', 'lake', '東南', 'southeast', '西', 'west', '少女', 'third daughter', '羊', 'sheep', '金', 'metal', '口', 'mouth', '肺', 'lung');
INSERT INTO `trigrams` VALUES ('100', 1, '艮', 'gèn', 1, 0, 0, '山', 'mountain', '西南', 'northwest', '東南', 'northeast', '少男', 'third son', '狗', 'dog', '土', 'earth', '手', 'hand', '胃', 'stomach');
INSERT INTO `trigrams` VALUES ('101', 5, '離', 'li', 1, 0, 1, '火', 'fire', '東', 'east', '南', 'south', '中女', 'second daughter', '雉', 'pheasant', '火', 'fire', '目', 'eye', '心', 'heart');
INSERT INTO `trigrams` VALUES ('110', 3, '巽', 'xùn', 1, 1, 0, '風', 'wind', '西南', 'southwest', '東南', 'southeast', '長女', 'first daughter', '雞', 'fowl', '木', 'wood', '股', 'thigh', '膽', 'bile');
INSERT INTO `trigrams` VALUES ('111', 7, '乾', 'qián', 1, 1, 1, '天', 'sky', '南', 'south', '西北', 'northwest', '父親', 'father', '馬', 'horse', '金', 'metal', '頭', 'head', '腦', 'brain');

SET FOREIGN_KEY_CHECKS = 1;
