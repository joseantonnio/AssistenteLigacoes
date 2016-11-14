CREATE DATABASE  IF NOT EXISTS `assistente_ligacoes` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `assistente_ligacoes`;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: localhost    Database: assistente_ligacoes
-- ------------------------------------------------------
-- Server version	5.5.53-0ubuntu0.14.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `chamadas`
--

DROP TABLE IF EXISTS `chamadas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `chamadas` (
  `c_id` int(11) NOT NULL AUTO_INCREMENT,
  `inicio` datetime NOT NULL,
  `fim` datetime NOT NULL,
  `status` smallint(1) NOT NULL,
  `telefone` int(7) NOT NULL,
  `ramal` int(7) NOT NULL,
  PRIMARY KEY (`c_id`),
  KEY `FK_Telefone_Chamada_idx` (`telefone`),
  KEY `FK_Ramal_Chamada` (`ramal`),
  CONSTRAINT `FK_Ramal_Chamada` FOREIGN KEY (`ramal`) REFERENCES `ramais` (`numero`),
  CONSTRAINT `FK_Telefone_Chamada` FOREIGN KEY (`telefone`) REFERENCES `telefones` (`prefixo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `chamadas`
--

LOCK TABLES `chamadas` WRITE;
/*!40000 ALTER TABLE `chamadas` DISABLE KEYS */;
INSERT INTO `chamadas` VALUES (1,'2016-10-20 11:32:01','2016-10-20 11:35:42',4,163032,5022);
/*!40000 ALTER TABLE `chamadas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ramais`
--

DROP TABLE IF EXISTS `ramais`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ramais` (
  `numero` int(4) NOT NULL,
  `prefixo` int(7) NOT NULL,
  `status` smallint(1) NOT NULL DEFAULT '4',
  `ativo` tinyint(1) NOT NULL DEFAULT '0',
  `responsavel` int(11) NOT NULL,
  PRIMARY KEY (`numero`),
  UNIQUE KEY `numero_UNIQUE` (`numero`),
  UNIQUE KEY `numerocompleto` (`prefixo`,`numero`),
  KEY `FK_Usuario_Ramal_idx` (`responsavel`),
  KEY `FK_Telefone_Ramal_idx` (`prefixo`),
  CONSTRAINT `FK_Telefone_Ramal` FOREIGN KEY (`prefixo`) REFERENCES `telefones` (`prefixo`) ON UPDATE CASCADE,
  CONSTRAINT `FK_Usuario_Ramal` FOREIGN KEY (`responsavel`) REFERENCES `usuarios` (`u_id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ramais`
--

LOCK TABLES `ramais` WRITE;
/*!40000 ALTER TABLE `ramais` DISABLE KEYS */;
INSERT INTO `ramais` VALUES (1125,167003,0,0,1),(1132,167003,0,0,2),(5022,163032,0,0,2),(5023,163032,0,0,2),(5025,163032,0,0,1);
/*!40000 ALTER TABLE `ramais` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `telefones`
--

DROP TABLE IF EXISTS `telefones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `telefones` (
  `prefixo` int(7) NOT NULL,
  PRIMARY KEY (`prefixo`),
  UNIQUE KEY `prefixo_UNIQUE` (`prefixo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `telefones`
--

LOCK TABLES `telefones` WRITE;
/*!40000 ALTER TABLE `telefones` DISABLE KEYS */;
INSERT INTO `telefones` VALUES (163032),(167003);
/*!40000 ALTER TABLE `telefones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarios` (
  `u_id` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(65) NOT NULL,
  `senha` varchar(128) NOT NULL,
  `nome` varchar(120) NOT NULL,
  `admin` tinyint(1) NOT NULL DEFAULT '0',
  `avatar` mediumblob,
  PRIMARY KEY (`u_id`),
  UNIQUE KEY `usuario_UNIQUE` (`usuario`),
  UNIQUE KEY `senha_UNIQUE` (`senha`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','Administrador',1,'‰PNG\r\n\Z\n\0\0\0\rIHDR\0\0\0d\0\0\0]\0\0\0S—\Ã1\0\0\0sRGB\0®\Î\é\0\0\0gAMA\0\0±üa\0\0\0	pHYs\0\0\Â\0\0\Â(J€\0\0U–IDATx^¥½We\Ùu¦·®÷7½Ï¬¬\Êò¶»ª½kˆ\èÍ€b‚œ\0f8C½\ê¥õ0\Z#dBšQH\äDhf¨ \Ä <I\0\"\Ð@\Ã4\Z\Ý]U]\Þde¥77¯÷÷\êû\×\É\Û]h!ô¢“u\ê»\Ï\Þ\Ëþk\í}ö	ý›¿½\Ñ\ï÷{‰DŒ\r\ëõzöÁ%\n½w^Ûƒ\ßÇ—\à\Þ\à7û¯\ÖÁ\ëúö\à¸\Ê\ÐñE…u/¿\Ý\ÏýQ¢£$\ër]—s½H3‹v\Öõº†-\Zr„\íå†¸§\Óõû#1öÃªG‡º…õ\äƒz©>G\Â\Ö\á\\·ß¶¨R½‚v²\ãúx\Ý\Ù<X4´\Ó\ÛÀñt\Ôÿ–°4 ®~D\Z¬ƒýÁ2¸&hX°–Á=Z÷=~8\Üûø9hôÿZh\"\r„\Ä!ˆ\Ò6\r\ç¸j	?Dc\ëF»0bFZ0«i\Í~\ÝjÝ²u¬Á¹–uBuk÷\Z\Önñ\ÛjY»Ý´N§\rcº\Ö\ívØ®ùj½O¢\äJ¾G&¶úrP\ßÁú³\Ý#\Æ=~\Ý\×A\Ûÿ¿VJÿ\Ù\'«\n\Òòx\Ú#¤MƒuÀ˜Áõ/—÷Á}X\ê\Ç\Þ[\ØEÿXyc(”›\ÊG’ChZ/\Ü`­Y?\\5‹V,œlZ$Ý¶0k<×³x¾g±t\ßâ‰¾%“fIm§ºOv\Ù\îÇ’‹Ea‡´\n\í\ê«lñF\ÕTýxn\ß.\çº]žùX[mñEL\ä\'ô˜Àý¬U\Ë\Ï\Úþ©õ\ßü\í\Í~ˆ\Æþ,B>¾\è\âAE´jÑ¾V\ÝÛ“¹!ö\çKIG®?p,¸¾§ç»™\â¯GŒKC\ï!\Ù\r£–ŒÇ°HHw»e\á\åG0º•\éö\Ú\\¡\Ú]k´zF°E˜@nV]üù!k¡-º ŽZ<·D\"\Ív\ÌB±(‡u-‚gQ4LR0Ð®˜\Ì5Œx|y¼\Þ^~ez§˜7\Ø,ƒ64{_×…þ\í—nq$¸`p±.||xp^\Ë`ûñýH$ö\Þþ\ãeh[>H\áJ?6¸W÷!w†bH \ÍYBœo¶ª–„pŒ¦ñDÄšª\í7\Ýô\ìw­XÜ·F¥b››V«–mxhØ²©œ›=U„S®LV³Ù²d\"aQ,¦d3\Ã6”²±\ÉIª±ln­IZ­Ùµ(\í\é ±(B=¤•¶¨î¢‹µAþ­‹yœŽƒóƒE\Çtù ý÷Á\Û\ì§	9Xt\á`Q~\ãAª\\P˜\Îe\ÎiQy\Úv\'\êö}Fø5z:š0`HÂµÑ˜>E5[g\Æp>e•RÑ¾ÿ\Úwlsý‘\å³	+•–É¤(\×\ì\Ñý‡¶½½e3Ó“v\î\ìYK¦2¶¾¾a\ë0i\rÛ¡C‡¼¾I\ì•Ì‹´ºR©óÜ°MN\ÍX6?l6\æ,“…	)‰)\á,Œ	Q™°A›_Â´E¢&†h3hŸ~‹\î\ët:~LÛ_û\Þú\ß~ù6÷½Ï€H\"\æû\r6³p~€º$A:Ž¨À\ècwI\Z¨[=®s}B‹ ƒ‹ô£G\Z\ì‹!­ˆ®kY\n3’\á`\È\ÆúCûOÿ\á/­\Ûl\ÚôØ¨ušu‹s®R\ÚGc\Z–\Æô¤S	›˜³CóŽÆŠ\å2(„\Ôç¸¦n\r®»u\ë–?tjn\Êf§\çlqñ»a\Û\ÜØ¶,Œ;rüþ(i\éxË‡Ä­E\Ý\Úo¦j\ì¨z«\Â\Òdý“\Å\î`RZ!\â>\Îm?®1ƒómsfhýó¯\Ü(tõÖ¢“Z9\ëûZ4\ì~\"¸FPS¿B-!˜‡\å\n\îG¬t·¡%Œ4¨|=\Ð\Â\"iS™º¦‡\éáˆŸ—´µ±M\ÐO\Z\Æ\Ä)óök0\ã/¬U«\ØüÔ”eyvm¬7*V\Ø\Þõ\çOON\Ù\"\Z0:<ŒY‹[¥V´t6m“ó³Vª–¬Q«\Ûõ\ë\×m¯P°<\ZŸS%¬^•Q§Z³‡\éZ¡TµüÐ¨9v\Îf\íÔ‘\ã\ÖIf­\Èý80\êÄŽEx:(¬a\Ðú(ð¹\í\èMû)\Â?¾<®Zg„ýF>ù;ÿòr°\Ë\"úùE\"\Ïc+\Ä=H¨\î @¿H\Ô\ÕB#¡£CÓ°ljÀŠf\ã`[‹üƒœ œ¥\ÊƒUa=#EcC\åšå‘¿põ;_ú¢\Ýó\Çö\ÑK—\ì\è\ä¸MŽY¥WµT:ƒ—óAM\Æ,“\Ï\Ú¦\ëþ\êC\Û\Å\ÄE¢a+\×k¶[(Ú»7nZ?\"H«:\æ³9;vô¸eù\íp£Vµ\Â\îŽU¹¯´¿A}`di\ÇbÉ°%³)œ{\ì\Ð\à+‘\Ò>j\Ýc\íó-}u‚e@ý\í;½–Ç·µh_8\â=ªU´|oÕ¹\Ó¬\Ó5ºO¿ƒ\ë9l«<TWfH\èÉ·ƒk¤\×^\×ñŸÿªL™3I©Ì ‚½*\æ%šLXb/¯Þ·w¯\Ù\Äü¸:¹hC3c\Ö²F¬(#ñG\Ó*õ2f…\à.µ[÷\î\Ø\Öþ®ƒ©\éY«¢­j\Ã\ÖV!\áh*5È¦3\Ön´\ì\Þ\í{v\í\í+–‰§m\r;{ò¤[Z´L*‚f†¬‰P”w\nv\ïú-\Û\ß[‡>U\ÎÅ­\ßm i–Á…á¬€‡„\Ô\é\Ã}\ï	\êÁþW	\Ý÷Zú\ï¿zG·À:E¹\èñE{.½\ÕM\rTg\Ë.)8¤D’\Ãaý\Ç5rØƒ\"9„iögˆGB\'\Òu•up\ÚB\"†4k\Ûõ«?²×¾õ÷vô\È\Û\Þ\Ùp±·»k[›”Ûµ\âþž•K%ËŽ\æ\çf‘ð=\Ú\Ò\'(\ì\Ù\Â\ìœK½\êðhe\ÉNX<·\é\éiž\ÝC+cv\ì\Øq[[[\ãü’f\Ý\Å/Y¯i\ÇÎœ°§\Ï^²\Íj\ËÞ¾{`1‚Ÿ\Ê\ÛôÌ¢-\à{*•š•\0\ãc“<ô‡ó6Ð¦\Ñ?¸\Î\r\í?\ÎÀÈ«¿û¯.ûƒ~\Ö\ê\Ô\Õ/\å<{ÿ|P\àAÁ1\Ë\ïeEu\ÍÁo`²Ø‡0P\Ð+\é!ú&Z`»	\\\íÛ·þ\á\ë\Øj\"o\"ñüH\n“Ó´{÷\ï&g\ßI»&\'\'(S\"j\Ô–}\Õ*UÎµlgg\ËZ˜¾(A Fk*¶µµ\ÛÀ\Þ!´ÿ)\êQNøÜ¬Ö¬°¹m‘v\ß\Z<§ID?5<bSc#¶³½a?~\ãMK%\ã\Ç$mIðL«‰MP\Ëi\ïÁ\Ä¬Zd§\Í\àW¯k\"Ÿúq9ŒÝ‡¬\ÅT\ÖÁÍ¾<ppL‹6õ<S¡ƒ}¯\Û\ÐÀµ\á½ßƒûˆHýWMLV¥\"\"Z¿\r\ì4»ƒ3¿òö‘\ÈI\Ë§mbj\ÌÖ·°\íh\Ð\äøÒš‚\à=›‚O=ýŒ-€®\æ\ç\ç-ƒIºô\Ô%ü\ÃQK§±ý\Ä!õz\Ý%¸Ý†	\Ù,Ú‚\é¡2™t\Zx¼f…Âžu:\Û0 ŒI\à7fgmll\Øöö¶ñK›Ô»g##9bÚºÀ¤Ñ¶C0¥<µŸ6œ÷—@\è\Þg®\\\ë´b‰¼ú¹?½Œ¢\\\Ä]\è¿«n<`PPPˆŽ€²\Îýô¯®\nxœ2W~š\ÕË’\Æ\éZ]\ãW\Ét\ìbö\Ío|\Õz m\\5\ì\Ø\Ã\å;V\áÆ±‘7?½\Úò:y\â$„Y»\ÕAk:6¿0o#££0-i•rÂŽ\Û\â\á\Ãv?1>>n£#cBÌ±…)”–¶)wXr(]³Œø¿u(v\ìö­\ëþl5DI‚yL\ã~¹„\É#^¡.°Z\ÕL®y|^Ë€–Z\ç`ˆPT:¸Ž\Û=X‚Á\rƒB‚}I\Ã\ãûl;ƒrô\ç\Ë7|ÿ¼|ý\ê\0\Ðý~œ‰\'±j\ßýö7­^Ý·u¥°ko|ÿ{¶·½M\äžp‡-_²·Gpˆô€l•R\ÙjøŒL\Ê\åsV\Æü´AU;\ÜA\åj5ˆœË£5iüÁ¨8uÜ–Ž.AÜˆeˆ=¿…²B´+O\ÙP&ùBcŠe‡\çÒ¾:ñ\Ï\Ú\Ú*f¬á¦U\"AÜ’\Éaö\0 \ÅÀ\â\Ð\Zþóv´o@#-J%‰~Á¶®(y“%\ì£Ý€\àÁ›\Æ«ˆœ÷E\Ç\ÛžRÀ@=Dy%\ØA\É\Ò\n\Ô]©ñ\Õo\ã¤ø”pû„U£“‰t\ßÞ¹ò–ýýW¿hM¤5›Ž\áö,J3:œ\Ã\\M*$°\Âþ¾§@f\çã L\0q\ásbs\îÞ¿c\×oÞ°5üH‘\ÍeAGD\â\é¤e\ØNÂŒÄ\0N/\Ì\ÍSö¸¥ax:•%Ø„\Ð\É4õ{ Ý®\Û\Æ\Ö*ˆŽ\ë\Çglcs\×Q\\“zMN\ÍcÂ’ 8š P\ÄµŸ&:‚$&D1M\í×¶~¸^\È0òËŸû/.iqyÿ:\éz\íû¶4\0r+\0\Ô1£T?®’Ü•é¨²¡\nð€¹z€˜Àý*[\×CŽ{™Ž\Ã Ä€š-	A¤k‰XÏ¾ô\×mU\ÌSœc£CC\Öm\0kq\Ú\éLÆŽ;a# ›$>d\Ós\æ\ÌY;¼xBg\Ü\\LNNr|m\ÈÁ˜þ É³DŒ>\Ì\Í\Ú*xsc\Ë&Al\Õz\ÅJ\Å}b®¢y¥IÎœ<ez\áLã°•\ËE€A!\Ø\\#ª\Ïñ\Ìcøž²5\ë-;~\â4-†s\ç~	¢\Ú=J‘ÀÁ‹˜ j‰\Þ0\á‹\è—cƒ•Àð3Ÿý\Ã\ËB:\ê\Ä\Ñ\ê>Á¥ÿ€€¬*PH\É\Ë\å¸\ï{Á:.„ŽÁ†£\nò”·\â¸N:3\Ä8iesL1\nËŸ\çõ\æ/žW¿Eœ2:¢ý\ÕøK“¼\r!¡‘v\æ4,e¡+\ë›.ý…\Â>\ÑzÓ’\Øú\Ý\Ým\ë 65œwn(O]Oa²°û˜²1P’5„\É\Ê\çó–Md09óhÏ»Vu5(g¨\ßt†j\Â\Æ\Æ\Çltt\ÏÑ·E\â“:ñ\Ñ\æÖ–kô\Î6A§E\ì”\êð\Ä—`~Ê™\Çl)z\ï{‚\ÖÁl¤\âa0\æH(9\ít• a\ì,ò+ÿô/‡\ÔÑ¤žB!–ˆ¬;L¹£b/\à¾ö\Åe¤kT8\ä~‡³H¾R*\ÎTŽI\\Œ\r\ÊðŠ\ê9:À¹.f †\ÙÈºþÎ\ìõü¶MYôÁÁÆ ›Y˜¶\áq\â$]\å\ÎöŽÝºy\ÓV.\Ûòò²=zô\ÈÖ‰+ªD\ç; ¡ÕµGN\È>ðX\Ía®ô¼<Œ9s\æAe\ç?L¥BhJ\É®<´\"ŒžŸµ!43š\ÒB‹Q¤cQ€\Ãþ^\É‘\Í\0‚²’É¬]z\æykt€\àø,µK™\è‚•V‹nüj_‹\è \ëT1€6#¿ö¹?¹¬<Bª>\è¾ôU\r\àB.—-l«ù‰A¡\â’K9\ë!‚¤¤Á¨\\œ2cÜ«\âT!¿‡õQ\èO‹L…LœR\ã\Âó!\Êxp\ë{pû–…qÎ³#£\Î9Ý™\Ù›œ™A–\Âtb–Š˜5l¤£²•\Ë*•Ë¶_\Üóx\å\êµw\ìúµ«¶\ÇuòqŠ\è›\Ä&\Ò\â\Ñ\ÉQ+W+\ëxZ$…f$qø\ÑDL\íù¯]\Ì\æ\ÚÖ¦^:*~Z?>1…\ßZ¤\áQÚ¾\Û\Ågž³&K\Ý\ÂqLŸÐºƒfzÇ•HHCat€~žMU‰¢¥®\ër\ZüòoÿÁ\åf·	g»\ØÈ¶ÿ*¸ó\Î®\Ó‚\Þ4­b’\"öó%»A=¥Q\n\'¸Ü¢¨f”\ZD©°®l&UAk\Ú\Ä!9/\ÊÖ½ó“*·\Ù`\ì_û[†!#}-Y_]³±¼lö¢37\ÈG…œ!££c6;3\ë«^†j\Ã\Ù\Óg\ìÒ“mIô,mc\È,©››\ë®AW¯]sÛ¯þ™·66Qm>‰Oðr‰þm¬»\æ@t\ê\àj\á\Ï\æ¦mem\Ó-\Ù\És\ç­BùA\"\Zd~U§÷4‚Š>`	·L–\\€˜á ŽE~õwÿ‚y¡ I±\Ô\Æ\áÁ\ç\ç¸X\'T°¨\"bJºu.°…Ò \":®œ”4‰3Ö§‘²\ï}®#™¡Å†;ŽV\0vZ5B¢q$µTØ´w\ßù¡#ª.þ ‹‰8‰orÿ:’\Ú@ŠÒ £Q4\çø±\ã\ì\É\n`ðž­¬¬xš\ä\Ú\Õ+¶½¿c\á7†0W-L\Ù>LÁx\Öw}u\Ãn]¿c\ï^½\æÎ¾\r±‡r\Ãv\îü7O5´sm;Á¡¯}û\Û\ßm©¹\0ŒA\"\Ñþyü\Ç0qN‹2ezD§€	j½\ís³[VrA–‰—•ƒ¼ú\Û_¸,\ÖD\æÀ78p\ã0\Ç\Õ.(\ÐMûqT›‹ü¸\Ô^ÁXª\ÆùU\ÏZ‡Ö‡\0}\ãÁ²G:\'­x\Äq\Þ} \"LHü%Ê®Cœ¤5\ê%[{x\ÇV\Ü\ÉlXŠ\à\ë\Ø\á#®\Ú]\ZÈ¦l“5„f´ \Ômˆ}÷\Î]{ë­·0%Eb–š÷*G•G£”º_$@E\ËZJ\â#d\Ú\Ä\ÈüÁú\Ê*Qy37\nr˜¿¢m¬ox\ÔÁµ›-‡¾Qõ¤\Ò\Ü_ñ˜¦\äY\ä˜Uqæ£“³ö\ìó/{z¾$ Z £E\à@C\Ä+QŽs¢ †\Çw=&!ŽR¬úË¯]\ÅßµœYÒª¦8*P9\Ü)\ç.#\ç¤8E‹¸­ž=\r\è¡]6\â\çe\Êd\Þ`†	 ¢¶­®Á$p\çC\\\'•%·ÿ­\ã€KHùO^{\Ýzµ–Z:nˆÀE˜k\ï^³MLF!\Óül SD\éûl«\Þjƒ‚?Á\\¥\ÔO/\Î\Û0Z\Ñ&r’ÚOMº6\r9\0\Ø¶vV©V=¥¢^¿	Êœ†a.ž˜˜²§Ÿ~š\ç®Û»÷@_h>²\r\Úzñ#Ÿ n\Z±~­‰¤C1§Ë€–\î? ˜¢}þƒ>\ÏÆ¾`M¤5!ÿ\Û×¯Bv‘end–\Ä9Ü ‘²oºK>DL•\Ð¢}‡\ÉhE/\ÆC¸4\æGjK\é-T’\í.\ÚQ\î\í\Ë_ù¢}\ç¿i)´#™ˆr¾i‡@9e\Ûx´j½ý*p7c\Ï?a³@UÐŽ\"ò\×^ÿ>ˆ§\çñ‡@L\ÑÑ£G\Ýd‰)|\Î\ÞÞž\ç­JD\é\çN.Ùœ\î\Õ \Ö\Í7mi	\ã\ÞôPgó¶f9\"r1B\Ä\Ò}C\ÃC637g)ü^a\í\Û\áÃ‡l{o\â\ç\ì\ä©3\å½ñ“+ö\É\Ïüª¥ˆú{¡¨\ÇQj¯,\n‚\ëÀ\\Q_(-\ZÊ’9ƒ8ÿ^\'ž\î£=¡ÿ\rÑ¨H\ê7;©±\ê\'¤ Júõ\ì¬$@>Ç‹aa#„FÉ‰‹1b\ä\×ÁƒŠ¡šÍ²7²\×oÙŸÿ\Ûÿ\Ú~ô\Ã\ï\âW\Zn®Ú\Z÷\àcF9ûL$ \à¸ñ\'\ÝjiO\ØÒ‘£ž—\Z…¸\"’PVD&356R‚ˆb„\Ì\ç\î\î\Ûû–À‘\Í\ÛÅ‹OZ³Xs¿óð\Þ}õŒ\ÍN\Ï`2›ö\æÞ°\Õk6E\ä¯\Ê\Ê\Ù\ë>EôT\Ý\Z ²:õB\0\Ð\âÊ•k–·\'Ÿz\Î^þ\Ø\Ç\í{?þ±½ø¡`J‡¨/7@ƒÀ\ìkg€:!´\è\ê(VLƒF.\ã0\È\ÑPø|†H]¦iÀ)N\é8«\î\Ð\r\ì‹\Ê\â¨\ßl¿÷78\ÎBN\ZÎ£ý0£\r\îññLÊ¾öõ/\Ù?~\åK–ñ„ i4ª1ûøƒX\Ö&($\ê\í\Ó¨\ãf¯‹\Ý\'.pû¾º\ny66ƒ\æ‘\Ú:f\ë\è\Ò\Ï\ê\ã“R6Á3À\×þfß¡¤¢\àn.“ó$£p_óEé–Œ\ã·0sBs‡`úðX¹1öÑ\æQù-ùMQ¥D\Þ\Ú\Þ±á¯¨\ß\èø„%¢W¦Wõ\Ð(\Ïc\ÐG\à\Æ\éC\Ýøñ2\Ä§ÿµŒ@\îi©»‚È§>O\âDE–9§4†\ä_\Û\Ð\Ö\Â¦+€©Á\ï`\ÕCÂ©d]0\Ðõ\Ü\r„¡\âøˆ¸}\íoÿ\ÆÖ®½kiù\Z \"	;\r\Ü\åúx?Ž©\Ç#i\Â\éI4C©’8·d …Y’/Qàµ»³kÛ›¶t\Õc4nJJ¹_\Ú÷\î\ÛGk«\\³jZ±$\ÄR²Š65pú\ÞGt\Úk\áˆoÝº\rT®\Ø6‘~‚§ad2•\àø\ßW\0\éƒ)ª%y\Ü\ã”X2e›øºÿ\è\Ç^qŒ*#*\Æq­[\Ú\èöD@F4\â˜\ÓW \Ò=\ísJ&\Þ\é¬\ã¢\à€ð\î”}\å¸N¬>pMN¹9Šb\Ê<®x\ì/Š}Zv¦\ÈZq±¤\"N%•\n\ïP\è>§Œó\ì«_¢Zuñ|K>‘¶P¡óý @p—{ZÍº?3™ XD–r™¬%@sBW]`t\rb\Ýe½õ\æ›ö­o~“8aÂ–¼w\Í\Ñõ!\r0¡\ÞÄ©Y‹Á`1#O\êW·AL’bµY¦otdØªhŒIå³Žoß¹a×®]A:611\á\éz¥`‚w˜g\ê*³*\â\ëÏ‰\Üo¨¾4U—;W8#œ\Ô\ÇûPü\Z˜\Ä&\ëO¼?D÷¼¿¾ÿ\ç‹\Ì\Û\ZþûEn\ÅV\àJ\à†¨\ê¹\ëÐˆN¯iÃ‚”•¢}\ë[_E­Y,öŒl\Í|¡‘®\ïb\æ\Â¡6Ey&\ÜUR3FYÈ“\×\Ç3\nhD³\Ä5Š¦+0B1\ÇZQ‡ µr\ß\Ôufô \Üu{k›2Œ`pÇ…%A‚\Ç\ïÞ¼\Åó %¦IZ©)\ÊT>JAbžû£\Ã¢õ}Lgâµ©÷q\Ì\Õñ§Pr\Å]R\n,ƒ(!“,“«€™_eE\'7]\Ô!\äj\á\æžê‹ŽRô_\Æd…`Í€¸Áúþ>t\áº\à¨!™J²ã«Ž\ÉY‰¬\Z!ð%sÕÒŠS\ÄIªôƒ\ï~\Ç*›[\î(“Ip}½\n\Ã\Ð\ÌP$£bú<0‰Bô`˜‘|‘2TÌ“ \æh\á˜\ÆüR\Z\ÔE\Ë\Ôp\ÍRR¯\Ô0o€®ŸA¢˜wž¨ð:&n•\à²\Ù\Ö\0\í°%ð57nÝ€.]«¢‘û%´x¿dµho}\Ý*\ì7aª\àõ‘#Kž¶\Ï\ágº”\'zþ\Ü\'>IŒ3\Íe@‹d°ˆð\èi\åY2óQ\"\âP90õú\Õy5\Zz04ò\ë8u?\à¤›%MZµ/fxÊ%½SŠ‡\èù¤£´\ê\âà® Å„­Qø­7ß°5ÌŒòR]Hš‚\Æh¸Ž\Ê\ë)µ¢ü*\Z \è>Š\ãW¬\Z+û,&õ\ÐR\å\ÈH¸D!J\Å¤q9U\ê)-\Ù\'¸“9:söŒ;yÜžyöY»ø\ÔE¯S+ƒ»ƒo˜)W\Ë¥5B¯2cÒ´\Èôj  \Ò1\êkQ\\Uov`hÇŽ?i\ç/^²\nqO?\×CKbB›ABLMm0…U\ÇD/\×v@%1CZ‰!¿úOþø²\Ã4\n\ÒI_%™¯\\¬\ê\É\Þ9“´\É\êš#( ¦P© Ó‹¡.­6ðVD\Å.Oz¾ûw\ßpgª€k|Œˆ»Qƒ\àº&s¯g‘XO\á\ËIò,g‡•Ý•\é\à*™¢:\rRÛžÂ¡Q\'\Èý\Ó\í;·\í\Ö\í\Û\îŽŸ:eO?ÿ\èhÌžþ{\æ¹g=½™\ã“>\ZE}\ì##£–ÁLi\ÜV*‘r´§^Hõöaº\Þ9}\î¼\Í\Î\ÂW¨„ÀÂŒÉ”ku\é—:\rV5ˆÁ s½õ«{¨3¿‘_ùÂ‰qµ\ê-úu‚;´jA4Z1\Ç\àA\ïýqƒ!‰Ž\àO$a!P–ü€T|q~\Þ\Ò\Üró\ê\ÊÀ‘\ËT½wºh?†]\áDBcjb1Á\Ã$¥]¢q\×`¦Ð²¶r‚M\ÊPÌ¢\á;ršz’ž+û/ó\Ö\Âd@_7oß±¯}õ«¶ƒ\æpÕø	¢v	J611ni\Ð\Ó\â\áE;…_8²¸hD\äÇwSu˜€rXT¬\ã.<q\ÉA@\â\Þk˜$P\ì\Ë!\ÊYS¾(\'y\ßüK¸Eé€¦>	’k‰\è\Äy×¤_ûü]Vg\Ä;–ô\Ë\Å\\+S¡‘\æ\Z¢$˜«c!Vùn\î\ÃuÁ°žˆôJŠ\ÜE)ËƒGœ3¼;°¹]‡­O>ù”\Íž³·¯½c\Í:Ø»•vbS5\Ê=\nCÂ˜\0ñ:ˆeÐ½Ž\Ì$\å©j,*½\ëc\â48Á53\ØÁ\â\\¬\æ’Án¼,Mð+ó©¤\ã›t?¹þ–\Ýp\ÏQ™ˆ¸C`)\íz\ÊƒA\Ø+¤³Å¯“O^x\Òò#c¶¼º\Ú\Ê\Û\â\Â˜ž²L—|G*	¤V1%`@ð\'ñ–™•/PA#	%\\¡\î\"‚‹\nE~\éwþðò\à\Í\"9XE«¼\ëB™ù`_K‚\Ò\"˜¶ej|ò\\º4\ëA¢%\Ì:  Šðü\Çt}\â¿\è\ß\Ãû÷ƒÓ®\Æ\êOO²‚v¸!¨—’š/\Ò*ˆ©ˆœÔ§\åå§ˆ®\Ì\éQ\ÞWCY=\Çh€þ\æ•|N¦]Ãµ–Ý¹~‹øc\ÇcˆZd3”vY\ÛXóºo›l\îl;œ\î°\Î\Ï\ÎÀ\à¨=t\Ø67w|ðž\0KO}? AQLÂ©?ýJCÔŽ€~Ôvf]”`\è\é\Ì\á²\È/ý\Ó?¸\ìD\Ó?ˆª[5RC}žFgõ~ÖŽ˜Æ¾$Õ™B\ÃE0¥\ÚuŸ3D6\\OV\ØW\Ù\â¼lK{*\ÜaiÁ³O?c\ßû\Î÷œ1nY2ùŒ\Õ\07	ƒª?(K5V\Å\Õ¬´µ¤Yy,qTc‚ÀbºBv<@4ˆ\ZK½Z %eo{\êó \îqœø\æ\æ¶\Ý&X\Ý\Ù\Ûñ´K*\Â·!b’\Äp\ÖJu|1Ë½»w,3”·©¹y‡É‚\ê‹0¤…Ö‹I1L¬€‚\ê¨?\ÕÙ© ºjG¿÷|¡¹\Ú0\ÆyqÀ˜È§ÿ\É.+&pÂª¡üj‘MöŒ—¦Ç¨MHPþÁ€ÿ@Yu­œ°l¢3Ì‰¨\Î6Ä½E@\ï+€\ê¥ûÁ÷¾o\ÛHd6›¦Ü° ©@‚ §\êYz†Rûzv\Ô½J\íùÈ’Qu”ón£¹_\é•\ë™¥:\É\Äjh©3¡Zu8Ý†0Q ´ x½®(¾\âQ­€¦\Zvü\ÌI÷Ó£\ê\ë€\ÑDñ\ÛûûVÇ¤Ua\êa%6\Ý\ê\àj\Òhµ™\ÕSFÚ–¤¬Ž1‘z¦£÷=m\Ñõ´ƒ8\ä.\ëˆ7–U…º\ÆpL\Ì	¶S ‚ùy$\ÐU\ãZ\Åbù(\'\Û~‡N°¡\nzþf‹\0±TS„\ï £\Ø\áI\×;o]±bi\Ûrù1\ËU·[\×B99]l»\0P5D©	œº@ý\å,Ê¦*—\æ/†ŠòGK\ÌS_E[~Œ=½\Ô\á^b”\ßé¶›\ÂO¨T\ê_yð\0A\ÙYa\â&ˆ=°ùc3Sv¤¶S)\ÛòÚª%x‡Ag\Ìh[&WÒ¢zò\çiZj¥5®Ya•…}«ˆú÷_ý1AªLC õÁ\ÅAƒ%¸PÇ…t´R:³´\ã§.ðB,.‘r`\Öt\Êe¼Ž„rqH)¤²[n\ØX&\é(«Vß°¯ü\í—\í½\Þö\îd™@eKUIS)4”m@ƒj©g‡`ˆLú/$J[ú’¾6mÂ”„	j\Ü[#øss\ãBC\Ù\Ø~¥ÿ½~<G\í\äA(V˜Ø¤Š/KùÐ¢¹#‡mb~šxæ¤½ð\Ò\Çžº­ol\Ûú£mû¹_ø÷¡‰]ù,¡/\Å\ë%Áð\r‹ˆiª\Û\â]\0\ß_œÆŸú\Ü\ÂI $]\'tvÀ5þ©n\ÊT8«ž\ØQŽ\ë^n\Ð/ÿ‚û˜¡U‹t\ÉZ\Ò\rU,¬TB\"b››•ºq\Z\Í\Û\Ûo½mw\î\è\r§º3‚Xûø¯&¶º\á¶\×m°Ró—™tSF\Ý\ãn*Y( t§˜\\DKx~Gö†ŠÁ\Ò\Ð$\Û\"Oˆ@³)Sü¢\ìn+ZL¡­M‚\Âuœûƒ‡lóÑº÷\ì\ï\í\ÛI ±\Ò(=Lð,~E\Ìut%\n©\èrP_\Ä\0	,”ñ?ˆö´ê™‘OË©\ìF—ˆ þ{ )\"„´H…»lqÜ‰}pM`’\Þ/X\Çù\ï½\ß›~Q.‹\ãl{mFg u`«Þ±PœP(\ì\0!8\Ïó²¼T\Â\'AC\Êþ*,©öþ\Ô\ë\ÖÂ®÷Y5\â%Á=)\Ö41Œ\Ì\âp&\r#1V\Ô\ß*mav\Ý\ë°\Å3\Æ<Oe«¯=…óo×¹G&P™P|Fdö\î•w\í\êOÞ¶•5««\Þ!xsA%4P½Q\Ù\ÐVtš\Â\ÞÁ†Z%z\ë\Z\×!òC*#-n\ÐÁj¸*.›¬_9P\ß~o\å\\À7/tP–˜5\ä¥;õrgW¦Zv¨eûK\ÅÀòeû{¢x½¡\Æô,ªò˜z{Öµ‘—;\ÌSŸmÓ–\Ó\ï ¢F \â’QlzŽkN?aþð\Ëvñ\Ây»q÷6Z ~¡«8\Ú 8%•#‹AôAr±Ö¨z*$„\Ñz‚\ß<CmU¾<IX\æE»wû¾\ínoÁÐ¸\Í\Ír\ÍÔªÌ²\èå´€$¢«¿À=V?½@7\r<\\Ò¥÷¼ûB\r(ƒˆ\ì\ïJ½r\Ì\ê\×üÔª¼\Ë\Ö\ëZ­RE\Ý+Þ¢=òb”Ì‰ˆ)\0Ð¥á²£\Ñd\Ü%k·P°JBp“ ´¿´GNV\×\ë~½	¥ô9^Áu1˜\âÄ¹g˜X$\Îó\Æsy»p\ê¸-\ÌN\Û\Èp\ÞF\'G\ìcz\É2qO˜–\ÃNØ”R$\Ä6Q´\ÞP_\Ú	£¢\ì(9©Ž²l<ƒd	ZS\Ä\ZI\ï&(+>@b\í\áªû‰µû\ì\î;ø2ýDO1E>O‚-Â‹JBjqó\Ïâ¾‹E\ç\Ì\Ñ\"Au1«T+\Èq\\L\àW\Î\Èf¬\êl+<\×}~/´r_Pž\\P&\Ç\Å©¯\Zc[}+\êûT^ªQ©YŸ¢þw‡¼ª+\\m\é8¿\éd\ÒRHb‰\ri\äJ³lz\Ñ:˜;9\ß	MŒZ8ó÷û\0\Ö\Ò\Þ6ÄŒ\Ø\ìÄ„%)3ŒùI\"\é\È6žN\Û÷Ž\0Ÿ\Ç2)›\Ì\çlÈƒP\à0N]©™J¥“× ¹À\0\"\ê\Õ\émPO\á\ãs/=1 5µ©Œ‹[\'¶+t€.\îÖ«‰\ÔG\ÈWhù?ý\Í\ëý˜˜â§ƒ„¢\Ü<h\áÇ£_/-\Ø\Ø>p	€°\Ô-@}º\Ì+@	z€\Î\ë8ûa$PS€h\'¦4þ\á\Ú\Õ\×\í/þ\Ýÿjpµ¦—r¨´\Z£[%q0-\Æ\í\0YJB@R´\Û}±M©\ìðy43dV-û›N#srl\Êû\Ô\Ë\Äo¾}•*„\í»?ø&I\éù´…•Ô´õFó HŒUujÑ\Z¸¸O°B+z\è»DÜ¡uzf\ÎG.Š!\ÝN\ßG\Ñ÷\Ñ\Ø>ÚªÁx\Ê^d3\×­¢Ó\ç»6ˆF4k\Ð×®\Å\É\Ëf\äÓ¿ñû—%õ~«üƒü„_¤C\î´u<°§\"‡Ž;au\r¥<+ \ÛzÓ¾Žz\Ù\Ò\Ä \Ò÷‚\ëe\Ç\Õ§\Ì\ê\í;\×ì·\ßb_\Åqˆ	nV §<´N©\Í\Ùš\ÅùJ\ZŽ$ó«k¤A\Z\åO¥\ì>õ‹\È=¼ÿ\Ð_‰VýH{>™\"j‡½:}|VO¯\Æ!\í\"f8šhÀtœõ~\Åþ\è_ÿ—ö¯¾jý\è+þnaô`D\n@ƒ–L\ÕÁ\Ýg\ÒfiÁ€\à¦xs¸\\\",—~ö—¦ê Ž@E¥ItCð78,.ñ\Ü=PE^ÿ\é\Ú\âÜ—?ñ\'°ºÆ‰™üyðˆö	\éh\0³4J\Ó\\4¼shÛ»c‘\îoø(\Ý\Ïÿ<O\ÉG¥\Ä5x!•\ÏX‘\0mus\Óvp®\Ê\ÞV‰kd:5¸ºRÁð\×\Þü±€®•j-(G\êÓ—\çman\Ö&&†-?”Bc\â>˜!žH6€É‰œ\ÅðE¿ñù\ß#ø›Á¿5ý\Õ\êb¹F|’µ¦\Ç>\n\Ñ	%÷Šž¹¦Q÷)\n\Ô[\âÿ$\áyôû\Ók\ä3¿õ\Ï/;9\×s£rV^w]\Äa±k°jü\Òûû’rˆ\æ…sœ\ëu\\]–ZT–WŠób`i„v<‹s\êÕŠe‡†\ìöÝ«v\çú\r—\îhH«F|p=«£:´J>*I\Ã\ÕÀV¿\í5b\Êsb\Ö\Ä\ìvðG=E\ß]½£˜´-½ûy\Ò\0i¼÷cŒ\rcN\ÒT¨e	üFƒº\èóŒÖ¸®>Z\Ñ.÷\âi›?l1\ê–\Z§}X„\'\Êñ¶|¤\ê\'	\ä\×5ƒö©žj³Úª:ŠA„\Û\Û\î\Ú\âD…Bü8…~z½\Ý\Ðô(Pk€1D¨\Ø{û\ZY\Ñ\âB_)XP•&¬\"²~	¦\ÄP\Î\'\Ñ\\q\ÈG¸\Ë7©’}]T^Íº >rG©{PV·S³w¯ßµ6þ \ÓB\Øo9ý¸\â\r\ê \rSÿ·\Z\ÑDX\êhW00/n…z\ËZJ\Û\ç³Ht\Æ\Ú0¬\ÒÛƒ\ÛÜ¯\Úý­M{\í\ÊO\ì\Úý»öhg\Ã\Z€\ÜD\æ\î\ìoa\æöü¥\ÍRyÏ»pe`x(!{6<1e]\Í\ä¼K %³†€ÎŠx.µ.–¬Ú„9:@Z	\èOÈŽº«H\Ý4…E-\Ñ\í«\ÇEÿ\ã_½Æ½2\r4\ë„O25¨{\Õ-ª”Â¿@ƒ‡Keµ\Ú°4%¦\n6$­8\ß*\è$žMCM4\ÖôqZv\Ýn¾{\Ý6Ü¶¿þšE‘ø1º¿¾At×¦‘Jù+]\"\é\Ó0¥F\âhK*ññW¥½²\ÕkJ\ìE¬Y¯[8\ç¹5\àœFÛ«‹W\î÷~\ë7\ìÒ™\Óv÷ú5\Û\Ú\Ûò\ë\ÕM\ÜD ªm™\ÒÂ•´f8iô§fù™)«Sn\ç®×¯CÀ\ìA°|ÀVF\ÔÌ·\ÖÁ2˜Aï½…“òŸ®(ªt~|‘ýÿñ\Û\êuu;(¸ƒši\ä‹\èA\"´/ü¯/SˆÕ©µ¬Î‚×»¨<D\áñ˜œ8(…\è\Æ\"™„m\íoÂ–]¿sÃ¶v7°*ª•\ì\í\ï|\Ã\Æ\àf¢Ö‘ÄƒHZ\ã—ôF’Ì•÷kÃ @s`0S-—\Ê¬\áˆ\r]YõÒ›X©ñ¼M\ÌLXˆûM\ØK\Ï?o{›V\Ü+ \r;V(l³ˆ† 5…rÈ¼`\Ëkûö¹/ü‰½Œ3\ß)n[¥U·L~3hEð‹ü„5>Nÿù«y\njµ£, \çû‹³Ž\ãnúøð ¢~o!˜üôoý3\ésP€;k\Z+³#;\ï^A)WENR7_\åz\á)g.oò_<©c²\ãrvT…¸¾\Éý-öËš*{öÎµkþR%E[z8\Ê\Æ\Ñ.ñD*–õò¥¥\Ê;©\ÏB(Kê¨’©&Z\Ò\í#¹4¨\É#ZÀ\×‚p\áÒ“öü‹\Ï[ó5\n;y\áŒ%S1«\ì\ì\È\áE é¬ Uœþ\ÖÞ¾µ`j•2R‰!\ÌQ\ØÎœ¿h?÷‹Ÿ¶eLžÞ¯6J´#Å³¡¦Rd•pz·¶è¢•V\Ë\É\ÏI\Üo\"¨nÖ¸þ½U÷¹¯\r‘gÕ†ˆ*\æa?ó›¿w9Ô“yAž9§S\â!\ÍD\ÅEL%g,\'\æS\ÞQ1i†\n\Ö\\W\Zjª>·¬L­\ÃAK/ÁŠ½\Ö0ŸÒ®½q\í-K\rc\ë¹w\åÞ²M\æ†lùö5k±\ß{%\ä\0\ÓF\0\ØÁÿ¨gP&¨Ey%•F°&k¢™²ºmÁÎ²\éu`l	i¿ùSšcvz\Úf¦\ÆmöÐ¼C\Ó\ÍõM[¹y\Ï_\î‘oÐ¨‘R«á™ˆ}\ÚWG€b™¼\ÅscöóŸúu\Ë{G\Õ#´)›G3¹\ÖS·\â‹)¬S\æ@\è`•\Ì–…\ÑQñS&^~—†@{ˆgÿî¯¾‰»ˆ9wó*˜“]$78¦|V,‰—\Ù9\'\É\î\éáª´\îMf“<D©0þ¶\Â\áL{°²f7\Öpz§$jwnßµ\Ò\Ù(\ì\ÚÆw­¶ñÈ’À\Õ\Ï[h®*B„–¡\Èñ\0gRGL fPô­\ÝfË’z6\ç”:\ÑðQ\ÍÀ\ÎZ÷\Ü\ÅK¶|\ï¾\í\ì\ì\Úð\èˆ\r\åóžC\ëR\æf\'N@Y¯…\ìŸü5{\éÅŸóI\Ì0N\0š–w(i\æRQ\èý\0¡µho\Z‘†<þûÞ¢ôü\î,*St÷;’4E”\rk\Ô\Ë¹\É=¨fÀ8_µ¯²\å•\ç\Ñ8+O“\Èù\ã5¦AR\äa8®XC#\Ç{É¨0S1GË›k  šJº´k`›j€Ùš)NÁ¡÷D\Â\0\Ûç¤‚!\"¢gm{\í6B`—±l<e/=óœ}\ê\ç?aG-º\Ó\ï E|\ÆöÆ¶-/¯ÀX³¯þ\Ã7,Lùm\ÊX/\î\Û\Ý\Í\r[G€\Z\ëd‡mT·p\î	;û\ÜV\à\ÞBŽÓŽ„û-\Íó\èf\\u .´´ 	¾­³Ü§žV1\ÑGÁ|\à/¸G¥h=¸\ç ­bJ\ä—~í³—ûB\ÈI#Ot©ú \å\ä”Ýˆ0C…I?4šK`[¿œ³“Ï‘Dw\à^i\éR©\íJ\Ñn­<@8¢–\Ìe©l\Ä\n\Û;\Þ7¡	]ö­\Ùú\Ãû@d\îG*;=P>B¸EQ•ôÁRm÷Yl\ç\Î¥»»þŽú«Ÿú¤}ô#uD—ªN‚Šœ+[\ë–&²\ß+”(:	,¤aD:i\áD\Ì\ZIb‹ü¨\Í9f3ó‡ ¤fS®LR+qP»œ,NÀ@;‚\ßÁ\Ê¬9va†ˆ¬Ú¡ûô«\r\í‰^NG‡[^ªÿ\é|ä“¿òË—ûQ\Íþ©`\rbBõ	x\ÖB£\Ñ	º”ú\îc\Â\Øp\åQN\Ê\ß‘øa>\ÔW ;Ÿ‡À\"›\\\ÙZ@ª\íTK\Ä/8c¥ca\ÙðR\Õ2ñ¤\Å l£°o;HlM€Rô|ì¡›Ã˜ ¬\Êó© Ø’Ó”³\×;yÕ–ú·59Yð~\á\äÜœ}\è•W\ì\Ù}\Ø\Î^8O\\’²\n\Zª\Éö«M¼Œ\Õ(\'7·@ 8l\å\æi®\ÖZ–\ÎÛ±¥“r¦Š#\0GX\Ý\Í\Z–¤\0B;]P„\"¢4IA\"9,‰ ­\È~ò+P$\ã·\ÐfaÄY´B?´\ÕSû0\'ôõ\×ý&\"™H{\ã­\Ç]a\Í\Â¸<Ž\Äh rIÁc:.\Ð\ÔGz˜n·Ujs…z\ÕF&G­Ä¥E\ì\ï¨Fo©†h´2¶J“tº5\Û\\^µ\åF1õ­-û\Þ7¿n1b’¼d‚ù\ëa˜\nE\Îz\ÅXCsô,ùi k\r\×Ê¼JÒ”Âƒ\ÖH½Œ3Ä­kˆgZn\Ï;‘”\Ü\Ùß³P:c#‹-iö\ÑT\Ì_¿ò{Ÿû}{\â\Ü\ÓV.TlouÁ£.@ùNó})q(¤%f¹¶:%!B&Z¨£´z\×kX•´\ÛC\ê<yž¶ š\ÐTSB	q\Écu8ù\ÐG^º¼µ½j\ÃD¹¥ý]K¡\Â\ê\ã\0*YB&L¿\"(q§˜\Êø¼¸ƒ\ÐxT\Ì	R¯y¬\"É°\ív¬\È=EL\ÏZ©¼\Õ;…\ØUþ\"<´\Þ.\ã\\ž\Ò{u¢\ã•\Ûw,‹?I¸úš5\"]Zø\Ó(U\Ú_±†\Z½¨©^5LHñ3©3K\Ô9z“JC{\'T\0	¥b\ÑýJÿ¡Á\ÃS38\í¾ý„\à\Ó@x>ü![zâ´8\ZŸ³\Ñ\Å\Ú\nŠ*‡Z@oª\â)™V™1\ï\è\âù‡ÀHC & ¤U%Ž\"¨Ô¥¡.Œ\éª\ÍqKEÒ–D\0|h\Ìa­QA\Ëih¤F¡x#·ñ\Ê+º`l¤z¿\'{V«”\Üq¦hu\ÔÈ³+š\rõ\Ô\ÝZuH¼º¶lë £X‹._¹u\Óv¶mœm\èº_oiH“CUõ^«\ï»Cª0itl\Ô\'	hÂ´\ÍG+4†c®4èº‰	’ò F‰1b•$Iž\ÖGG\Úhv£ú¢úJzÎ‹g\Â+Ž\Ñ+\ÒôšµGÀ83;ò\ë[\Û=4:møGÿ\Ò^üÈ‡mATf@(RÃˆ&Aaz½¾W±¡T†x)lmb¤l&\É3k¨4’úBB)«\ã\'qG¬À\ç¨\Ìz\ruh\0Œ›\Õ\Êgž\âÍ¿\âq\Zmñ#²\n<WBž³O\Ð ³¥–‰\\õ¶’\n¯\Ä%\âRÙ¦5«DÀ\Ý\n+¦h[¯-—O\Ùù§.\Ú\ê\îC»·l\Z³‰…%üEÜª\Ø\ìh8\îC/51¥\é=Fˆ¦÷F¦fg¤A&\íkÓ¸º`¨\ê&hºSe®Tq¯\È\ËX¡>@N½†˜Zi Á©/¢Á:]Ad	S¾:™–Nœð~½+¤735eK\'\Ú\êö†\ÞK:\è\è \ÛÀ\ã#ÇŽ\"Q\Û\Ü\Û\0„¬[M\î\Ìf‰AR”\ëÖ­[-Xƒh>Þ¯[Z…\Öp§‚F´-ú\Ï&ºxa\ÎUw¬¿kWwQÿ’E¨_¿¦Ÿ\è)\Æhr6Ežyú\Ì\åBq\×\Ö\×Wt\à¤\Ò@Â\ÍMÿ®Ì¹\Ña\åŒ6¬^Þµý=õK½PS´`»œ\ç<ŽD\Å\ÒD\í=p~\Û*o\Zú)\É­5TS\é\r\Û\Ô@\è$\Ùd{û\Ñ#L\×>ûagB  ZÊ®j§Ž\röõKq.ùJØ©DR–I¥|ôú,\Ì\Îh\à3\×F!¼f”\Í9S§CÉ´\Å þS~\ÑR##V@¶iƒ\"û$\×\åsžöIa<\ç?üž­?ºg\ç¶•û·0+O\ÖW\îb¾·lwcÙš\ï5ª»\×msåž•¡W»‚\Ùt<¼{&`cšUL[Û–\ïÞ¶½\íM›œšvÄ¨\Ñÿz\í/ŠpE>ö‘\ç/\ë\r\×\í~ç‡S\ë\Ûý\å{Hv\Ïöñr\äˆ5R‡\í\æ71”·‘o\ÛÉŒX<;aûÜº£a\êª µ—\ÎÂ \rQmõPý\\\Þû\Ã\Õ/!3µñˆ!B]‚½ºð0Ht\Â|´@\Ð\\Ì«ñ¦È‡\ÈÌŒù,?šœL\à´Ä³€ƒò[\É\×û\ç=\0C’HüÃ¯þ¼<ÿ„ý\í7¾\éŽ}|b\Æ£\Õ üY\æ\Ì.-\Ú\Öú*\Ò\ßDPŠž\Þw\Ã,Å±\"šö|zj\ÜQ\Ùô\ä8æ¹9\íø¹<~YFyµÑ‘¬`¼\Ãc\ê\Í\æ½m-ÀŒFó\ï\ï\ì\î½\ÛúOÿûÿ\ÜoV\Ú8f,‡=X~\è\Ñ\íú\Æ\éE\Æ0%f˜ò›ó#µ\ÝZÁ^ø¹OÚ»wW\ì\æÎž\Õ@\Å\Ë\ë{He‚\ÈHd\Ý)b71K¡\Ä\ÇÁ5‘\í\âŠ\r\r\Ã¢\Ö(\Î9Žš\Þ~û\r»ñ\ÃYoØ§A\Ê\æ†É‘Ë”)…­j\Ä1\Ì\ß\ä\Âhlm\Zt!ð¢^\Í,\Ï\×\ê1l`\ê¸\Ñ#÷l|b\Ú~\âó¿k§_|Nö\Úþ›?ÿ\ïl\áø’:~\Üf&\'l8‘±\×Ú¬.€4Ìš‡É¯ý\Ã\×\ìðÂ¬­Ý¹c9„)¦ \â\æ3i\Û \Ö\Ù\ÚÙ±…CG\\RôÆ•\ç\Â\0Ÿ—…6Ü¹{\×\Æ@m\0E‡r¯\\½f_þ\ê\ß[\rF+>\ÒK±\ÅF\Êùk8¤º9o=¸o[ $9\ë6R¸zfvÒ“…k«{ ˜¾=zÑ³C6{\â‚ý\è\æC»¾Y¶µ\"6’µx&\ço©\Êy¥A,!¤]yM\êGõ=\Ë\Ü\à38¦±Vª¬:‡­õ*Z*¡÷Apš^‹\"€\ÑAå‹¥‚i6k©|˜M:¤n\â\Ü\å[p\\À\æˆu\Ãø™z	0Ñ³q´9?6\ìÙƒ!\Æüì˜µ\ÐüB³Œ¸‰¶M1Áò;\r¢Ü¬XM\ï\Â\ÜRü“\Õ{vò\å\çlm\ì\ãü¯ßºm½Ž¸G\\\Òððü\Ùy t,I\ÜB\Ò9b¤.uˆ[nd\Òò£ Þ˜}\ç{¯\Ûúö–}ÿ¯Û·_û¶\Õð\Ãa’XL\ÌK\Ù\áÑ¼…\Õñ´[,[\n\Ç{þ\ÒÑ¤]c³\Ø\ÔY\ìZ\Þ#\Üó\Îú \â\íB\Õö\Ê-»{\ë¾\í\î4lsQ\Zý„\Õ\Ð.½\'ú†MŸ`L\Ú\áoÑ†\ÚHF\ÝG \ÊøÛ°€`^­ˆ\àÆˆ4Ð …ýöwö\Ø.—i’©\Ó{\Z­Q#\Ö\Ñ\\½z—P³¼©­\ÃEŠŒu½†€®aŸ76óH\Ý>1\"\Û\rû‹¡§Ïž±ù‰Ûª\ì\Û\ÚÎºƒ\n½\Å\Õ\"kVRuE”©kr@h¢}=\â”û Á\ÙSg-’±HvÔŠu\êDÌ–Lût•\ZŽF\äG\'\n<z,c\ÛV­ö«>û\ÜñOnh\Ø\"\ÐDZ?2<„v\'¬\'@\"xN;#O^8}yt‚¨óò\0§u\ã\Ö\nÁq•·y`\ÍbÉ¾-KclÀ\ÖKE,–_¯¶mµn\Åõ\Âd\Ñ\ß\Ñh ½Cù´cm^R.”$d¤dš¹§Öª9“Zu%c0B@eiûD“K\nf{ÀÇ¯\ì¬@®\â\n½R–Ð¼†hL\æ\nwuc\\>£uÒœÂ•\àú%\Z?™›\à\n:£\æ(\Âv\æc±\Ñ#G,3;no\\»jË·Ø¹\Ó\ç\í\Òñs–MfX„P¸#(\Z×®\Ömth\Ô\Ø\è\è¸\Ë#»ü`uoßš“è²\ÌLò¿\á\Êv\âø	Ÿh ´¿\Ú\Âq\\ó©¼þ\Ý\ï\Ú\Õw®l -\Ü×›\Â	Ì·¦©c÷Cü/þyxzØŠ{;VU0„C\ß\Î\é\r\Û;¦÷\ìò\Ã0$a\Ë÷·\í×¿ð\ÐÀ¨mC\Ð&°T+\â7p„X‹­\ím\à^Úžyñ\ïû\Ë_ý2÷§m¿F*1g\Å\Ú.\rOYa¯d˜–”\Zª\ëë¶¶r\ßvôV‘¹¿Í„‘\á§[üÏ¾¢f6\å–ð3!œ¦0|>NŒ@#‡ˆÄ—\Ð†Nš³]½6\í>ó\á\Ø\áçŸ±\Ã\çNYz|\Äþó¿h?zýûö[Ÿü%{\æü“@\í$Ct@(¡YL\Î0„ò—>Ô£Ù¬ hy\Êþ¯þõ¿²oüØ†©[”z\Æ\Ò`:3ª.ýcã¶»\Ì\Õöø¸m\ã“776­\ë¤,\Ò\ÎSV&h@\Æ\Äø¤¿ý›\Z¿|\ãþ=\ÐQ-HGö\\ñC«\Þ\'\Þ\0\nF‘\Z7>»h§\Ï<	¢\ÊYû´)É³•”cbD9OE\Õó‡æŸ³\\W!–)avhœ¯r<xb|B ²úMû(`L#Å•Z™Š¯$\nÞŠþŸU\ée®#˜…\Ç\Êi[J—{…¢ºµº\ry\Ï\ã#\Ír,‰.£•2…+»û\È\'?i§ž~\Êr\Ã\Ã^Î~ø†›©Ilü4DKb\â4\â]@F£&‡1A\ê\Ò\Ø\Ïó¡šlù3Ÿþ¶Ÿ8\"Ÿ\Â&2)Ì›\0\Ð4\Ä\ÍÃ¼©‰	›œ ¨k¾È¨‚\ä4Å”ÓŠ{Eƒl6cO]zŠvöü\'‘óŸ¸¬ -\n\Ñ{\Í\ÊXq»l\ã#Ó¦|\â\ÞfBä¬ˆ;}ö\">¤f\Û\åŠõ°“ùa‚>\Üh¨3…dk2\Ê3\ç\Îú>·\ïÞ²_|ÁVm8ò\Ð“ŠR\Õ(\\\"\æ0¡¶[±\\ôJ«ÿA“w0;š›W¦A\Ä÷8F\ÊJs”N\éP¬•Œ\ç±Fð“C\Ý\0qˆ\å±6\Ú\Ô\àÚ› \Ç8ð¥}Ä–NŸñ7õ‚\ÎO~øc¦®\ÃHÿu!R‡)M|•F\Äh”dGö¬)\\+h†\íkš\r\Ì\î\ÙO\Ú\ácKvö\Ùg\ìÈ‰%û\èG_¶gž{\Þ.^ºhOÁø\ç_xÆŽŸ<‰\rÀFý=Ai}¾I¡FR0\Èñ·û7\íCz‰õ\Ã>q\â”žY²‘Ô°\ÍN\ÎY·A$\Z\Í\Úò\íGV-µ,Ÿ­˜>z\0ŽB„6R£\×\Ò0 ¶±¾…V\åmgk\ÏU^c´¨\ëUCQ·¶6^?£œ†\Ïø)\É\ZSÿh\Ør˜·h*m)$÷\Ôùn‚\Ô(»<LÇƒ,ŠÓŽ\É~Á€6Œ×ˆóT$©J\Ùpò\È\Ü\Ç6„†{¶\ì\çYÛ˜a\Õ\áã¯¾\ê\Z\ÖýH\ê[\Û6A½³0~h(g‹‡ý\é }O†P¼%‚©-aŽEømP™~:n‰Óšt\ãKG\ì\îÎ¦\í:Tc]+}{0Ó¿APýú›?´køfež\'¦\'l‚`tŠöŠK›¯|ü£\å@e\"/¿üüe\åk$eC`õIN\È\Ähl¯²j±b¹\ÉI›\â)´\0qÎ\\\Å|º£Y\0M\Ý\éK6«ø!žKNñ6l{{\ß^@‚nÜ¾\íL½{Šž\Ë\ØK©u<‘³6` z\ê\ë»OC){ô\È>¡!˜Ü¡ÌžODc©•ó\Õ[–2\Î\ÛS8\ìˆ¯ùQ ©zoD=•[•²5Bq;ÿ\ì%;ÿ\âK˜Ü´?ÿ¯ÿ¯¯ø¤jB[\ê›9w\â$\í¦¯b’\êûE‹T4\ÌV\Ýµ„\Ø\Â\Z4¸o’˜F)ÿ<&i\æ\Ð!û\á\Ûo\Ú\ß|\íKö\æh\Z›7n\Ø[o¼…I[G\0ƒûs˜T\Å6\êN¨µ\êv!Fs‡4Vl8\ã\ã\Æ\"¯¾ò\Ê\åÒ¨¹\r•«)¨\0¶RQ¤ô‰—_¶\ç_ýE›™›±N®\ÝU>\è\ì\ì$AÕ»WoØ£\ÕËƒ÷KŸ$ÈšÇ™\î\íz\Î*T”\Ý\æy.zY3Õ»€\àžÁ14Á;›/Xg«ˆ\Óß…Y0X›\Â\ìhôZ™R@	¼\Zƒ°>0\Z\'\îs´£mJuk\Ê\ï\×\éu\å]˜¡¸$	Ðžÿ\Ø+6ì¸…Ð¬\nü\ïþþ\ï\ìÿ\Þy¦O$	•‰‘²\åòÂ†\nì„€Â²÷\0*k\Ð\Þ+\â\Öw®T–F-\ÊL7ˆÝ”Î©\î—\í\æ\Û\×\ì\Ñýö\àö\ï\nP\'1ñ>~˜ghŽú“§N\"t\Älˆ¦‰¡Á\áfd{ùžW ¢v“3‡ƒ»töœ\Í`ó\Ò\Ø\Ô3\'O;ò˜\\˜Á²§O\Øû\Ê\\\0²$úÒ™™ “ñ†rPú•\ÐØª1%QùKÇ€\ÃH£¦¯ù\Ô\Þ1’b¡\Ø]&\å\èÉ“Þ™\å\Ì\0H\Zðn€ª\Ða\êtö\Ä[š›FÊ›6\ÔNÀ\ì\áT\æ&ñƒz\áfˆXiO¶Ó¦&§lrŸ\È5;˜°\n\0`qA\Ãü!\\šPYƒ)\ê—\ÃUŸÅ°\æuDpvôþa>©xø/\Ñ\ì\Úþ}*ù¨\æ|¯#\'\Î=Ay![œ]²gž|\ÖN-ž°§O?‰“lÚƒ·o\Ú\Þêª›G…´\æ.Ñ»&\Î\ÑÛ¿y\â\Ïûí¬®ûli#CiLR\Èf¦\Çmzj\Ä.¢Jù ¦€Y5\\›F(¦¯4\ÛMÓ¼\éš\ãP\ß\Ù\ê€ý0%Kct\éQÞ¿ƒ\ÃV“R\n\'TVÿø\Ç>f/=ÿ¢}ü•Ÿ·T“£À›~\Ç;£ª¥*\Çc>A¥\\Ÿ€sõ\nðuj\Ó\n”:~ü°e\ÓIˆ0k\Ç¶#Hú\âüa 6h°\Øð¸Bi÷üÈ¸\Ïù›CH^{ýu\ê9\Ð\à®=\\^q¿#R¤\æ{\×wDG\è:MpÀ…\0\r\"q´£X,9\"m\ëµ<¸,Ÿ¨\ÌÁ‰\Ã\'\ì\ã/}\ÌJk;6\ÏÛ³\Ä7öeû\ÍO|š\í6…¸tñõÍ˜Þ™\×TµÒŽU”\á\Ñ\ÊC»ú\î/\àÀgq¨¹h©™\Ý0­\r‹6w€wE+\"ù‹¶Q&:FM[1ˆ4\Î*d\Õû…ÒŽK»V®lrr„\0\n\ç1Fócv\å\êM«€hš!\Z•\êZgK%°\Óú\â@\r\ê\0¦\ì¹\ç‘8$\ß4®|\æ-\Ñ(\ÚH»b\Ùê¾š±W^|Ö¦1a#•\Ù\Õ\n6\Z\ë\ÛôXÖŽ-\Ì\Ù<A\ë\äô¬\í\ìi¾v\àk$c™!´µÙ¤½ýÎ›v\ì\è‚õ\Z\r\Ï[\é;$\Þ\Õ,gˆ\0\ì\ï\á0\Í4W\Ñz8‹E\åÁœñ\æP\Ú\Þ\äœ4\ä­\à‡J¥º^:i§O³p½d\ÙF\ÇZS‰ˆ}ô‰\ÓöÌ‘\Ð&\Ö;>Ù§4}c“LÀ\Ý\äùµ}\ë›Jš\ÆG’€,\Ô\É¤ b\Ù6\èñs\çl§®iðd¾4úC*+ø¹¾±\áR4ž{þy\Ñ‡\È\è9:6‚FµlS!«iVõ™\"E¨šF\ÇDU4§t\È\â´j&\éHjdj\nŒ­qiZ\ï§O\Ù/ÿ\ê¯ú\Ä\ÆE\ë\à\Âlh µ²Mex9”€Ia\ZXoVq\Ê\Ò\ì˜Z<l\'Owó©ieõ«¨?E4,H\Ó\êBGsœó,³žÍ’Bûµ\ï\ï}°¯¦\ÇElkU÷­g\0<J¬JP?ù+¿f]|\ì6«¢=zwD(T\æÊ­»¶@\Üs¿uþô9„v\Ä\ßcii¨-\Ö$ij$D\ÔK2RÁ0™š]°¤\Í[À7½J¦^4½ª…1Ê¸J\å@’H\Ìÿý­où´«ŠK4{›ˆW9(1F\ØWp°‚\É\n„D™}2HÓ„0¿\Ä5C6§or`6.•Õ·ž\áºy\"ï¥¥\Ã<ª¯r?N	\ÖD\ÆqõNR®^AP?J³]\Ã	÷,•%ž\0ŠŠ\Ég.\\pS\Ä#‰£\Äút…¿A;k\Âö‹\ê\'¤\è=–j+\Ûe§\nAO%\Ð(	¥˜%zÉ¼Õ¡º­\Ë\Å:\á\ç?ûY+%B\Ö˜l\ì €,	¦k{6–\ÌÙ‰ù#6…`{¯§\ê¥$jXý\æQ\Z*û¯‡k’{€#Žôý\Î÷€yiº3óF!!\"ôRµ±©\ë“>\ÆJ9\'1D\Ñxkk\ë8°¼¯ú”†¼\êš\ìX=‚\Z\è,Iyµi\Ì\Ç>þŠ½ôò‹ö\nõg?ÿ\ÏlnqÁžx\â\"‘ÿ‚QlQ‚R#5Ëœ&€\É\â+4\ZQý\ÜUà³´¤Þ¯\é\ëø³Aª\æ]”\íó\ÇoúüðšqH3n \å’\Ü\à{R\ÄEBj\\R¯}9v1D±‰b(1Uš­bP€z<Ë´¡†\Þ\ã7L\Ô}\î\Å-£Wì¦§õ\nÏ¤~¥-kU\Z\Ö ¸Í§òþ½%\\5\ã¶4Ð®§ÂµBøj¤Lfn¤\n\Öô%Ž\ëuei\Ñ-$/o.Û\ë\×qžÁ@7MP,ISê¾°¿ƒôkl•\Æ\é\"©™!\r\ícû±\Ã2š{\Ý8®Y<¾hþBðx¡†\Ï\0Ÿÿ\éŸý™>È¡92/-Ê®«}P\Ût	QÂ‡uñGm€CMWW‚¾´Ö§]ó‹‡lhZ3iZ\r½e¥¤ \Ïõ«²pM \ì¯2;$\r:\Æš\â#]~[-e­ƒ÷õ¦ˆ§`X_ó‰#˜Š¥Šõ²\ÕñEû\Ô\éøÅ§mhv\Îú0SY‰\\ž0_Á´E oº6Xy‚÷NvQA\n\ëƒúH\\È˜‚p\Ê;\Í\ÂU}\Ìdnr\Â\Þøþ÷­^\Å\äP	I`‘Fm\"õ\ãh\Âql³4B™YŸ X\äÈ‘E‡\ÅCÀ9\ržÐ—\Ñ4‰¤f\0Õ‡Qr¹Ln\Û\æö–O\éŠ]˜;:=i¨0X_€ã‡\Ò ¥44ý…@™g\Ðô\ï¥\Ë<öÑ€*è¯Œ\Ôo[£Þ¶>\Ú8}ø\Õx¶†\æH;ý\ÓvH¾¦×¾P ˜--C¤:/+ M\Ðq%9uL\ÐXS\Ñ\Ê\Ì*\Í/\æ(˜”6)œF8zÐ±?k”[„VcC/°6Â©A5§¤>R™%l\Ðð¥v+¡\×\á\Úø©R\Ñ\Â-LU”=¢Óª™	”w\ZBEõ\Ås\Ä\ï/{\àR«W@7ÀL\å¾\áö½»\Þ=1>a%0µb‡½½-Ìˆf›Þµ¡\áœg~\å\Ì=zè³‡*ù§™¨õq.\Ù\"©{\rÓF\Ò¥_ÿÉ›V \'Îžµ\r\Í\nô‰	õñ\ë«\Ðb¨¢þ¥ú»#˜WA\íŽ~}}\Ë¿¡Š6»t\È?Éª\ï†\\¹z\Õm¿¤}¥\Ñ0ó®­\îYÞQ?@†s\ê4S§([c4óœ¥oR%ÑŽ\Ñ\\\Þ28\ï(\æ>’€žv8÷tP\ZÁ§¢V\Ç\Ü*Í€r@\ï0Z)š¸û‘i`ùñY¸Oº&•\ÙDºe¶ZÀ2I\Ô\ØH\Îöõ\í& ! \"¼\ÔiŽB\Ís«	\ë}6ˆðÄ“‘Äº½ù“Ÿ€Fú¶¶N\Ä±ôºÁPt¯°kgÏ±§.^ô‘„²\ï\ÊS|£\ï\ÕBJÓ›U\ÛH\É\éóg}\Êoÿ¾}|b\ÜS\Ør¦J\ÑhÔ¢\ÆCW\Ö(L\Ïøˆy½\ä©W\r\î\"<½n\Ä\æ[œH»Ž ¬no‘ƒ±¿\ZF¤7z0–Áÿ\Zt!³¥\Ñõ\Zß¥¾uùF™	f“`´­xƒvù¼ò\ÄE\ZžÔ <iQµQó\ék8ö6M<Pa¥\É÷P¶:©Rü6\Ã-\Ëa}Nl;y\Ê?&£‰\Ý\ÊûŸ:*œ“V\Í7’G¥)™”¿Z¶j™˜›ôžÀ>\r÷ú\r*•NA-K\0%s¤]\Z£ùp\×p’I$dkk—À«r r¦\êÐ¹~ýŠýð;\ßC\n\"VFºo­\é\Í\Ø]\íT,´¾gS½¨\Z\Zóù\ß\Ç\'G‰Ò¶t\î¬õ°¿i\"(<„\Äe0\rQ¢\ç®\Ô\áƒ0\äHµ>\àE0Xn@Œ¶µ\Ð\âÌ±C¶ô\â%\ÛŠZ\Í\ß\Þ)Z2”°D7F°×³5 h\"N\Î\ÌY• S\é MLLÁ¤‡b”­Ä¢º”\Çj$Š\è\êrnS\Z¥hx“\è\ácÙ¨S„x«¥\Ú~x\ÛKY‡`1Œù\Ýp(ÿ3:3FŒ$3h;7H@ùØŠS®7r·B…\Ùjz\æ™g\ì\Æý;v\è\Èa\Û\é\ãñ9\Z§€*G5ºo\ç¬\Ï\Ñ\éB3™\Ì\Èi†”m}s\Ï\æ/z_€|”Ï«˜\È\Ø\Ô\ÒKM°A\Ò\Õ\ZŽ\ËT€\ÝGFòV ¾)\âx›\Û\Åd5\ÔP@FMNSN,Ll“!v³N?¯qU‚À”\×Ek[½†\Í9deP\ÏCÚ³Á\ë‘\ì\ÅÁbM\Ï\0^Æ§\çA‘\ê,‚0J\×ð«¯÷\èŠ0Pywwô	¶5LJ\íVNKþ\Æ}‹º*û%ü›ž\Ñ÷OZl\înZK\Ú8<n§ž~\ÉvyN³ªqWo¾ð\Þ\ÃÑ§m\nŸ™\Ã\Z\Å#0Ì‡\Øô±Å }\è\×?]A#<\à¡š½scm\Í?î›…úP¯ Z\n¨¦\×\ÉZš\á€\ÈV¶öÒ¥§\Ü\ß_¾o…rÁƒ%M\ÖB}•Ù•\Ú71o…j\Ãmgau\Ó&òCƒ\Ûvó\ÚÛ½ÿ\Ð\Â\åŠ\raZø}zbBß³ÕŒ\×ý67…Ã¬\"\Êy\ÇX[\É>v°A\Ó0½^+\Ótüy#B?b@,C\å‹\Ú8Tö÷q°8,\ÄV¦K]¨€­ú*œrh]9]\0‚ü\0\Øjòw\\/S-ß¡x\Ê\Ç £M\nO5¸V)›T(…jû÷NÂ™(Œ\ÇT£i±6fk \Ù+*…¸ÕŠZŸÖˆ}Õ²#ilaA-z#iIO\çmxv\Æ?\Íð­¯~\Ý.]x\Âf\àv-Ò›Obˆ¿\Ó\'\Ú\Êò]\"\Þqÿ\ìÄ½{·AT)G”¬¸[°1\îÓ·Ê·e\Çah?5–\ÊX\É\ZÆ¼‰aNb[G\Ó\Øü\"DAH\Ú][Z<†Ô¦!‚^ÀX¢\Ê ËŸ%ð>­7R\Z•vÀ¨ºF-\"Û»¢G\ážòÆ„Þ¿{\×j@\áu–\èU7}þû\áò„)\æS“kF ùeg5P\áön	AbA]ý\ÊD\É\ÏBs\Ôóo:9aQ\àx§Ÿ&ø”¹\Ö\\]\Ç/<	\ê#4\Ø\Ú¸`\î¬ˆE*‹\Z–\ZÂ„!\ãn·õ}>¸^t\Ñ?\Ò\è\Ã\ç\ÎY<›³‰\é9\Û\Û\Ùóš¨\ëtH6>‡³\ÝY_#¹O\Ã\Ó8Àš=ù\ä9\ÐÔŠ\í+&¡aîªp ¹¶ŸFkŒœ\áöêš¿s®|\Ø\Öö:·d5L_{k\Ã\Ò\Ô Bƒ“À`cQC\Û\ÄC²ðð”\Æm\ä †^\×cn„VTH[„ô9b\ÓÓ³˜Ž2ˆ®@¤]sdT§Ž’n½‘¥‘)YÌž\Ò&ú|…FÙ‹ðBa)\Ìx0\ë´/¦9,†K\n\nU†œ¿^0\â–¥\ë\éÁh\r\Â2Ôœ¾u|]‹kõ\"\Ð(\à&E0«Hp²*z–º‘U¯º\à¹\ÞmÕ‹\\TrL¯y\Ä½ˆ?:9§—lbfŸ¶o}\ë›6†\Ô=¼»Œª\í\Ù0L8~d\éh\Ûòò=*Ó·\ç_x\ÎN>n›4v\åáª­b–º½0Ò˜Áôð`¤I“Mfó\Ö+\Õ<‡CR\ïÜ»eË·®\Û0Rù\æW¿b§Ñ¼]¤W\Ó\ï^Zb®Ud/\ÉDY,¯Ie“”[÷Ÿ½bS	4ÓOC %„Uœ³\Ö2\Ó3\Óø›4~o\Ë\'\ãŸ\"’Ö¨\ÎZ`%|ª@\r\Ä\Üh¦kÜ’›piú\Õõ}Ž_Ñ«~ƒ—sD#]«—•°¤„-À¡4c>—ÎŸ³.&²……}1†ÐŒ{š°:\Z\ê\îÐ0‘4º\×qRj\ZR3‡#Vd¹_\î\Øü¡#8\å	\Ô{\ÙsIQPGf\É\Ê\Ä\í\Ð\á9ÿb¦\Z¦‰\îã‰¨\ÃÛ••žl\Ô¶\î\Ü}\è¦ei\é¨\íi¤9’\ÑC\Zk\Ê\í E@=ËŽL\Ø^ÿM\çGm\Z_q\ãµ\×\ì\å\Ø\àßRITD<³R¹8\È\Ño\0+	ð@úÀ¤b!®(e^<\ê ø<:6\å\ç\ä@§\ç¦\í\Â\ÅuQ®>xˆ„\Ôj8­2!´B–@I\Ò™)™(i¿ %¦\ì`[‚\"\ÍS4Q¿4†=\È\Æ=X\æ­)]\ài\"›N2f™9˜)M•‰bS,\Ölš%\ÇÒ„ü9\ÝF\×v¶÷m\é\ÄI«\"%\Ûõ’\Íž·ù\Åy¤<e\ï^»ac\ã#ø…]®957KŽUp²RµW>ú¸ðÖ•·lWi{4ƒ¸\Î\ÆÁ\Ü[[k\ÖW$¯OcSŽœ\äð\È(ˆ{¯dÿç—¿b\'Æ‡\íú¾o_ü\ëÿ|¾\ç®cZ—\×WlõÑ²m­­\Úö\ÆC 0ñB6l;¥ÿ\\\ÒÝ»÷‘^Í—‘Ar]½£\Õðñ\Ö\ÆD“Q\Û/\í(~iar\ÆV¶Wl\Ñ_\Ú\"\â \ZwP\ÎW\Ê± °úrtŒS\Ä2ñ¨‚¿pP/Lx¾*\'&*3>L×‡\'s\Ùêš·\é\ã‡@l=_×Š\nt\ë\Zð\×ô‘”\Ée\ÉNfp®>œnjðg-Y8z„˜£\à)p\r“?w\á¼MCÄ·¯\\1½£)‘\n{;ž>?sü´­¯naÓ‘ \Z%ðüs/@„¦·¶}dû\Z\ÄôDbn\ÐPµû«lk‹\0°H%ºöðy{¸ó\Ð6\ëvç·l˜\æ\ZZòÎ·þ\ÑR˜“i`µ\É\Î\ÃÀm\êU¯5luy\ÝJ»EJ\å}R\Z\ÍÛ«\Ù\á$µcS“õ+v\Ð\ì\"t\Z\ÍV–A/Uøl½š:\\ó»\è#“\Z+%I—\Ä;gX4\èB$$Á\Z	\ã‰\ãƒhšrCRCJŽ=Ô·\0ZlP\Î>Ú¦\ç\ç,\ê\n¹Kˆ”~¡d\ß\Åm´\ìÿ¸£X1\ìF\0\0\0\0IEND®B`‚'),(2,'user','04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb','UsuÃ¡rio',0,'ÿ\Øÿ\à\0JFIF\0\0`\0`\0\0ÿ\á\0\"Exif\0\0MM\0*\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0ÿ\Û\0C\0		\n\n\r\n\n	\rÿ\Û\0CÿÀ\0\0]\0d\"\0ÿ\Ä\0\0\0\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0\0}\0!1AQa\"q2‘¡#B±ÁR\Ñð$3br‚	\n\Z%&\'()*456789:CDEFGHIJSTUVWXYZcdefghijstuvwxyzƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\á\â\ã\ä\å\æ\ç\è\é\êñòóôõö÷øùúÿ\Ä\0\0\0\0\0\0\0\0	\nÿ\Ä\0µ\0\0w\0!1AQaq\"2B‘¡±Á	#3Rðbr\Ñ\n$4\á%ñ\Z&\'()*56789:CDEFGHIJSTUVWXYZcdefghijstuvwxyz‚ƒ„…†‡ˆ‰Š’“”•–—˜™š¢£¤¥¦§¨©ª²³´µ¶·¸¹º\Â\Ã\Ä\Å\Æ\Ç\È\É\Ê\Ò\Ó\Ô\Õ\Ö\×\Ø\Ù\Ú\â\ã\ä\å\æ\ç\è\é\êòóôõö÷øùúÿ\Ú\0\0\0?\0ýL¹ð¶”@ÿ\0‰^—ÿ\0€±ÿ\0…P\Ô4=\Æ\ÞY¦\Óô¸\á…»Xð “Òµ®´ƒÚ¼«ö¥ñ›xkÁV\Öp’%\Õg*\Ø8>Za›õ)Qƒ\Ã<Eh\Ò]Y\ípþU<\Ë0¥‡\Ûvô[·÷}ñ\'\ÇV\Zþ¤\Í›cº Alƒjúž>ñ\ï^u¯^\éó—cc\Ïq…R¿ñ\ËvÌ‹#cªœ\í5\Ëxƒ\ÅQ\éö3L\Ì\Í\å!`¾§·\ëŠý_ƒ¥FšŒVˆþ\Ò\Éø{ƒ£=$£¢\Ñ×‹®´\É<C}\æ[Yü›a…DJ6 \'§Vb\0µ\Åx–>\áX%½ª¶{\Â)šö¼ó\Þ\É7ü´\äœ\×?ª\ë¸qm\ÝyT³\Ñ\æ\"ŠŽ\É}È©¥Ù‚G\Ù\íó\í\çô®+\Ç:lb\ÖB°Â«‚\0X\Æ•tWzº\Î}\Òkž\×/\ã¹\Ü\æükÍ­\Ê|\Þ3•E¦—Ü\Ô\ï€\Ëiã‚~\rÖ¿³´ùŸV\Ñl\î_\Äøv\ç1öm\ÝûU\ïŠ>\Z\ÓÇƒuhÎ•§ª­œ¬\Ä\ÚÀ1µK\n\ç¢\×Î¿ðO\Ú\\—ö`³Ó­\íô\Ù\×\Ãw÷:tr\Üy›™w	—\î0\ØÀW«j\ßu­gD¾³›M\ÑÓ ’\Ý\ç\r3:IPs\Î\r~s‰­\ÊP~gñ®e•}Jo\ì\Éý\×ÿ\0#ŽðG‡l>\×\Z>\Äü£­ºqúW \éþ\Ó\å•Wû7O\ê9û2…r¾³0\ê…\Æ\'Ò½#I´Ài|±®q\ë^=\ÙÖšrº3\ï4\r;\Ïli\Ö+Ž8¶NJ)\Ò+úó\É\Í·)\ÏÈ~y1õ¯œÿ\0n-G\Ê\Õ4X\Ùö\Ç¤²±\Î‚\ã$û|µôQ\0\×\Äÿ\0ðSÿ\0x\Ò\Û\ÇZŸ´½7Rº\Ól\ïPûwú´\ß$žH \Ìnpx\ÎÓŽ„{™v!ajûytO\ï\è}7‡ù”pº\ÇT‹’§;-\ÝÕ—\â\Ï;—M¸Ô—Î†\â®2²Á\í?\0\Öf¿£\êRi^JA©\\\Ýjüm\ç\é\Ô\n\æ<û}\ë\Þ\n¾±\Òþ-x7Pð¬:„¢]j8¼ý2Y?ºò.Dm\ìþ£š÷\ëi\Ú\æ–$³ºGóˆ*Ñ°<\å\éÀ\ÍzŸ\ëf+šÒ„m\ê\ÏÜ¨ø½Š©\ïÂ„4\é\ï]|\ïú2jV²\ÚÝ¸’Wnv‘‚?\n\ä|U~°Û’Ã¯Ò¾»ñ}¥­þ”ð½Õ¼\Þ^\Å&\ÆVú\çùW\Êÿ\0\ítWÕ¦†\ÎûMµ›q&12•?Aœ¯\áùWu(„šhµ\æµ>ƒ\âž»\ä\Ì)ºw\ê\×Ý£ü\Ï1\×üJÁCÛ³ß¨®oVñ‚¬;–O˜v\ÏZ¯\ã+¿²,±,‹\'–ûÎ¸\rŽ™\êzó\Ýw\Ä?e¶=’	\'¯Ò»kb”£\Ítz¹†2Œ\á\ÏBJQ’\Ýj™ú}ÿ\0•\Óñû)\Þ]É†:‡‰/%\0ó´,pGü\Ð\×\Ò:u¼˜-mõZùþµñ\ë\Å³gˆ´™-\Ö;O\ëÌ–\ÓÌ¾|K#¡ª\Ã9\ï\æÛŸ°†{ß¯JølE;\ÔmŸ\È\ÜK\ÍÒº–üÌ§‹j’+GV\ê\nœWAiû=‹©pk%dÁw«Ú½\Ò\Úi	™¤?Ê¹½š¹\âó²\ã(Ÿ\å^1\Ø\ÑMOõjd!Y†q‘Àüh£Ø«•\í\íñ6Ÿ\ã-\×T\Òo!¾\Ó\ï“|3\Ä\ÙWÁúA ‚W\Ë·\ç\ÃKoŠ7—šB\ÜköR\ÞE\\]ikkrÀ7\ÝN>_›œŠÁø!ñ\ÊoÙâ„š~»1‡Áþ%»?i\à˜´û“ò‹\Èú\á€²(\än\r\Ñ0\Û?¾1iºŸ\Å]e´û\ë+\ËHm¡Xn#a,R¿”»‚y\Æ\ì~8©óQÓº>³/\Ékañ®\ÉÊ“_µjÉ½¯\å\ä|ƒ/\Ã\rG\áÇ…uM7AñŠ|I¤\Ì6\Üi^&›ûRQœ1\ÎðNq\É#\0|½kS\àhºðÿ\0ÃF(\ì¦Ó¬\ìI0\Ä\Ò4\ße\È\Î\Õ=vŽƒÓ¥nx§Æ–º®¦m\ÛMµ¾˜!y%Š&\0=N+\×5iþø-i\Ú\Ëu\0y³÷÷¿^}¹ÓŠå”§t¨x\ZXvš>9ø•ñ7M\Öu;„Ôµn\Þ\Úü¹“NYe’F`~T\n¬Û¶žp8\Íx\×Æ¿„¿ü\'¦bóÀ¿4»©M&±%\ä—0ÈŒ\"•¹\É\äm,9\È¯tð&Ÿ¦\ßx\ÇYÓ•l\äŽKƒ<i,…<¾z\êNzt®ÿ\0\Åº¹ðñ[JH,•DIS›–\ì\Ã\0~uÓ‡­$›wü;•º¶¨’~ªÿ\0©ù\ç§x¼/\ã-\'Pð¿‰.µj@¤ñ\Ë9‘Z6;q–ùS\Î Ö§Œg\Ú>\Ï\'ú\Åb­è¸¯jñ?\ì4=f\î\îKvÛƒY‰Wy=\Î\Ð2}ý\ëç¿Šú\ïØ¼k\"ª\îk…F\n£qg!r¯\Ìk\Ö\Êñœñ•9kÁU=ž¦\ìšk²º\é÷«ŸðH/\Ã\á\ÏØº\Æò8\Õd×µ›\Û\Ù»me·_\Ò_O4¤d~•ù\ãû-Á@døCðC\Ãþ\Ò|g‡í¼™§»\ÔI<\å™\æ\íPiY\Î;8¯lð‡ü»G»ºŽ?xgP\Óan·W\éS=\ÙQ€ú>Õ¤°5\åy\Æ.\Ç\Ægœ\Äñ5±\Ôð\îP”›Vjö\é¥\ï·c\êH¥.ÿ\0Ê¤ñWž\Þ=Í˜\Óð\äÿ\0õ«Ÿø}\ã\â>oª\èz¶©§\\ð“B\Ù\0÷R:«\êÀ\ÜWAs:¶­32–ò\ÈÛžy\î6v?89Ó“„\ÓMh\ÓÑ¯TCuL‹p\ÑùŒ¡¾bƒ\ìh¯1ñw\ì\Åð¿\Æ~%¼\Õ5/…þ\Õ/\ï$2Ow{ \ÛM<\ìz³3&I>ôU\êx\íhú­¿‡cð”ðMý \×\ÑË£\\·V]\áJ1öV\ë\ÝOµb\èvskvF\Ò\âM\Íp\Þjª·\Í*„hÿ\0\à<c\ÕYk\è¯Ú\á­Ç‰­¼7®Coou\r¼2œoœaÊž‡wAŽ\àšùcÃ—\×W>(¼¾·i$¸²½_>.Œ\á‰\Øõ\à’+Í¬›‹}~\ãõŒ&J‹…í®«\Í?\Ð\Ùð\Ü:_€5¨\ìn5;K]CT9ˆ\\\Ü’wùˆA¸ö\0\áGe<u®“\ã\Ï\Ç8t\ï<7Û¼\å€\0‘F\Òû\0}\ì“\Æ+\ãW\Ãkiú> W\Ï]/V¶\ÕQ7‰m¬=Õ™s\Û9+œñ·…|I\â™go\nÙµöŽ¥\Ê\ÝZ\ëpY\ßD‡—6\Ò\í\Ú\èw&øÐ©\\1bI¢.h))N/ž¯\Âö}Ÿ™\åÿ\0ô«oÅ“kri·–\éB9c¹`w9\0t$ž{Ws{\ãa¦\Ø\\C\"ü°‚FAq\ìkñ\Ô:¶•¢Eb¾0“A¿’a±‚\â=N\é\Î\0m¡S\ËU$’\Ãn\nœ†¯LÐ¼1om\á;\Ù/v\å]ò\Í\Î\ÍÝl\ãÒª´y!ÌŒ\éV›÷\Ó\Ðñ\êZ÷†\îµi<\Ë]6\"\Ï8Á}¹\Î=»WËº\'7üGó\à„^]Ç½ª\ÜL»ƒÿ\0}\n÷\ï\Ú?\Ç\Z\çÇBü9°k\è\Òe¶»¿È‡O\ÓöŸºÒ‘‚Ë\Ì\'¶	\â½\Ûö?ÿ\0‚t\è¿\Ç[–)|]\â\r¸ûm\Ì%,a\à\æ8ù-ƒÑ¤ q‘Œš\ì\Ê\ê{{Iu=|—6£–\ÎU§«{%ý\Ã\Ï\ÂÙ‹S\Õô«pkh%šòh\Ï_¼ò\à÷f\'ú\ÖG\Äo‰ž‹\Ä2øwÂºaº]-Å½Î®KH%”¿\Î8\ÎN0N+\ê/?Ò¼\à«\ï\í×…4›x\Þ{\ÛX®\ÝÞ€¤·\ÊB\à}\Õö\Õò4ßµ5÷\Æ\r4\è~ð>Ÿ øUi#\È\ã9Ý…\àg®?:÷(\æœV*.+E\Ñ_ñ\î}\ÎS\Äy®q˜\Âs‡¹£d¼\ä÷“G[ð§\ã/‰?gŸG¯xn\á#ßyc>M® ƒø$\\õôq†S\Ðõî¿µ—…ÿ\0h?	5\æ‘3\Úk hiW*\ÜY±\Ï=ƒ\ÆO\ÔsžBž+ó\×S\Ó.l´˜V\ë\ïL§nLv®?ˆÚ§ÁŸ\ZYø‡E¸û=ý‹\î\0ý\É\×ø¢q\ÝpGò85\ë\æ\ÙZœ}¬U™\éx‡\á\ÝÎ“\ÅR\\µ¢·þn\Éÿ\0W?ct\"òö\Ì\\Iq>y,¨~b \Ï\åEyGÀÿ\0\è¿~\è~-\Ñ\ÚU²\Ömü\ß+‚\ÖòVH›Ä’+.{\ã=\rñÜ²\ì&Õ£:st\ç£N\Íy£ªø-ñ~\Ç\Ç^Â—Rª\ßiqýœÏš€a\\g<•ÛŸ|×|cýšaðö¡6©¢3YÞ™<\×\ÇÌ“ƒ†ü€È¯›|eñ^ø\ã›/X«M\r¼\Êg\0’¯F\áô#>¾Ù¯¯<ñ\ÛMø\Ýðþ\ÇR±™f†ò,\àõ‡§\èAø\Íz\ÜI•ýR»k\à“º}›Õ¯ò? <F\àú™cõ\Ì.¸z\Îÿ\0\á“\Õ\Åþhñ\ïx‚\ßV°º\Ñõl\îm#ž$ˆžvŸ\â\ÚN>„z\×7®ü\Ô/™\×LÖ´ÿ\0²É–\Ï\æ¡Ê»Žÿ\0\íoôñ4,ö÷C÷Omdnyô ðA ‚\rr?²g\Âüzœ\Ý_ji>µ¸–\Ù\ï\Ú2n®r20‰\ÈFT0\àù\Ç\Í\á\æ\â\ÚLùH\âe§s\Ï<-û6\Øøk\\k\ËÇ‡ÌŒ\ìÞŠ[q?Á\Ç9öþU\é\Ö²_ˆ¾:\ÛÁoª[É ø6\×3%‹Š\ëWqÿ\0-.R>Á\r€3¶¾­Ñ¼+\àß€úGÚ­\àŠk\ÄO\Þ]ÜŸ:\âR:œŸ»Ÿö@\Õò\í¯ÿ\0OÀ¶W\Z†vË¨\Î\Æ–/\á=3þ\ÑôÝ…i*j÷›»\ìy\Ò\ÇV\ÅUöxuwµ\ÏDñþ§ð\ÛöHøp¶ÿ\0f\Ó&¼Š/*\Ö\Ö\Ú\Ù#M\ßÜŠ$<÷ü\Í|­ûFÿ\0ÁFN«\ékªMyu1\Âh^#1Œcƒ„ÿ\0u	>õòž§q\ã/\Ú/\Å\×Sj\Z\Õ\Ã\\K\äHþi;û²\îþ\êŒ|£\0\ç½{\Ã‚zW\Ã8­Um£7Ró¸ŽxÀ?«(ük\ß\Êø~¶-óMò\Äý†ü1\Äb¥	\â\ådþóšð\×Á-[\ãwˆ\Û\Ä^.1\Ã	r\Ði\è[Ês÷}Y»nIô\é^ñ\áO	[øgLû=¬J[n\Ðm_§¶)t\ÃªÆ¸ŠS©=\0±?\Ô÷\ëÞ­A«\\_[¬–q\Çkb¼}®}\Ç\Íÿ\0®h\ç\Ï\\ð\Ü+ôl]G	J(þƒÊ²]IS\Ã\Å+}\ï\Ô\Íø‡qk\á\Ï]\\M‰®£ò\ÝH\n==\0\ë^\ã­òûÃ·\Z…\ç\îV8\Þf\ã¾~`W¹\ëPý±·H\éQ\à\í1‡žSý\â:\'°\äó\Î:W#\ã6ƒVV¶™!Ž\ÕFfÜ›ö(\è=Ú³\ÇBéœ™\Æ!{7~\Ö=þ	¹û[Y|ø}¡j·B9µ5\Ä(ü\íáƒ§ü9üMó7‹´\r7MÖ™cš{\"‡0FZO/=3\èqƒz+\àª\à\æ¦Ò·\Þ3\æ¼3F¦2¥Ko&Ïµö{\×<}d÷jÖ¶\Z|\Î#d²\ß=\ë7EDGU\0\àüç‚p@&¾†ø3û0\èÿ\0~\é\Ö6ó\Ü\\y+%\Ä\í,€»I#³°\È\0m\Ú\n=\ê2ÿ\0\í,´÷Š?.\Â\Æ\â\ê2J1@J\à\Ï\'“]7‹µÙ–\ÉZC\æ«|›zb¹ø\×2«W\Z°Iû³õoüªñkˆ1ŒJË¶„R•—VÖŸr<Ÿö…ñ{}ŽK[\ëH\Ù\ÞWm\Þ^<95\é\n5UðŸ\ìý\á¶\Ò\Ú9m›L†De\à>\ä\r“õ\'?S_\"~Ö¿\ZuøGZXc]ú¥\äZVý\Øh#w’¼u\ã_SüŸwÁ\r[ªªD\ÚtaTtA·\0a_3*n0ö‹\Ðüºµ\Z\Ë\Z\íûŽ\\«\Õ+¿\ÌùSö\êý©|Pºl\Öz\\\Ëj(\Ó\ï;—\×Jø\'J\Ö\Å\å\ÕÖ¹pfk›½\ÐY¼\ï¾I9\ÃJsÐ±\'\0\0\0õ\ë_ \ßðS„\Ö6?\ïµ8eš;•B~\\“_›:L3M¢\é7\\Qrl\Õ6\ãhERsþ\×Ojõ28\Æuo=O²\àjtiâ½¤\ãv•\ã\ët¯øŸhþ\Î\ß\n\íü)\à»9fT/ö:F<ny>cÿ\0Ž\à~.¹¨ý«\\Xm£ó$j Q“’Ç€>ª8õ\ëN\Ð|[;øQ\ÕWj\ÄJ(\Îx¸›/OañhþfIgkma¿ƒŽ1½¹óÁ~\ÅN1¥N(þ­\Ëðñ‚¿edz†8„j\Ùp#}œƒ%¼r\áD73^H\ã\í\Çöµµ®{hÿ\0†?¾q\ë#Žý\Ô\éý\ã’*¾›i¶7š¶ûF¥oUðª1÷@ù\Öo‹õ\ÕðýŠµ\Â\Üj\"VË’.>}UÆµ’²º:+\Æñº\âK\Èaý\ÜAUWŒ\'@k\×u&Fò\áEš\á\ÎQO*§û\Í\ëŽÂºWŽmzOžH\á(;c\n£\Ðs\\WüC7‡uy´}1V\Ò\ãj/\ï%!¸\Â\ë\Ï\ày¯+0©\Ë\'±ð<EQÂ“œ—\Þõ<‹â‡Ž\î<%\â\Ùl\ÒF’EP\Ó6r\ÆBNw{ô\ã·N\ÔW\'\â\Ù\ä‡\Æ\Z´1·\Ëmtð‚\ã{>\Ü\rÄž\çüh¯†©+É¶ÿ\03òSœ¤\åwý|\Ïÿ\Ù');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-11-13 22:40:43
