/*
SQLyog Community v13.1.7 (64 bit)
MySQL - 5.7.20-log : Database - crud
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`crud` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `crud`;

/*Table structure for table `information` */

DROP TABLE IF EXISTS `information`;

CREATE TABLE `information` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `last_name` varchar(100) NOT NULL,
  `middle_name` varchar(100) NOT NULL DEFAULT '-',
  `first_name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `information` */

insert  into `information`(`id`,`last_name`,`middle_name`,`first_name`) values 
(1,'Sample','-','Sample'),
(2,'Last','Middle','First');

/*Table structure for table `vwinformation` */

DROP TABLE IF EXISTS `vwinformation`;

/*!50001 DROP VIEW IF EXISTS `vwinformation` */;
/*!50001 DROP TABLE IF EXISTS `vwinformation` */;

/*!50001 CREATE TABLE  `vwinformation`(
 `id` int(10) ,
 `name` varchar(303) 
)*/;

/*View structure for view vwinformation */

/*!50001 DROP TABLE IF EXISTS `vwinformation` */;
/*!50001 DROP VIEW IF EXISTS `vwinformation` */;

/*!50001 CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vwinformation` AS select `i`.`id` AS `id`,concat(`i`.`last_name`,', ',`i`.`first_name`,' ',`i`.`middle_name`) AS `name` from `information` `i` */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
