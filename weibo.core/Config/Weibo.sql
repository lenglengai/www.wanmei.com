/**
 *		作用：		创建statusOption表
 * 		表名：		statusOption
 */
 CREATE TABLE `statusOption` (
	`accountMgrId` int(10) unsigned NOT NULL,
	`tableId` int(10) unsigned NOT NULL DEFAULT '0',
	PRIMARY KEY  (`accountMgrId`)
	) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/**
 *		作用：		创建statusMgr表
 * 		表名：		statusMgr
 *		表的数量：	tableCount
 */
DELIMITER $$

DROP PROCEDURE IF EXISTS `statusMgr`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `statusMgr`()
BEGIN
	DECLARE i INT DEFAULT 0;
	DECLARE tableCount INT DEFAULT 20;
	WHILE i < tableCount
	DO
		SET @STMT := CONCAT("CREATE  TABLE `statusMgr_", FORMAT(i, 0), "` (
					`accountId` INT(10) UNSIGNED NOT NULL,
					`ticks` BIGINT NULL,
					`statusIds_i` INT(10) NULL,
					`statusIds` BLOB NOT NULL,
					PRIMARY KEY (`accountId`) )
					ENGINE = MYISAM  DEFAULT CHARSET=utf8;");
		PREPARE STMT FROM @STMT;
		EXECUTE STMT;
		SET i = i + 1;
	END WHILE;
END$$

DELIMITER ;

CALL `statusMgr`();

DROP PROCEDURE IF EXISTS `statusMgr`;
