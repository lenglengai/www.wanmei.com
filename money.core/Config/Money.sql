/**
 *		作用：		创建money表
 * 		表名：		money
 *		表的数量：	tableCount
 */
 DELIMITER $$

DROP PROCEDURE IF EXISTS `money`$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `money`()
BEGIN
	DECLARE i INT DEFAULT 0;
	DECLARE tableCount INT DEFAULT 20;
	WHILE i < tableCount
	DO
		SET @STMT := CONCAT("CREATE  TABLE `money_", FORMAT(i, 0), "` (
					`id` INT(10) UNSIGNED NOT NULL ,
					`accountId` INT(10) UNSIGNED NOT NULL ,
					`value` INT(10) UNSIGNED NOT NULL ,
					`total` INT(10) UNSIGNED NOT NULL ,
					`dayInc` INT(10) UNSIGNED NOT NULL ,
					`dayDec` INT(10) UNSIGNED NOT NULL ,
					`maxInc` INT(10) UNSIGNED NOT NULL ,
					`maxDec` INT(10) UNSIGNED NOT NULL ,
					`debts` INT(10) UNSIGNED NOT NULL ,
					PRIMARY KEY (`id`, `accountId`) )
					ENGINE = MYISAM  DEFAULT CHARSET=utf8;");
		PREPARE STMT FROM @STMT;
		EXECUTE STMT;
		SET i = i + 1;
	END WHILE;
END$$

DELIMITER ;

CALL `account`();

DROP PROCEDURE IF EXISTS `account`;
