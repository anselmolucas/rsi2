
--
-- Estrutura da tabela `addresses`
--

CREATE TABLE IF NOT EXISTS `Addresses` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AdvertiserId` int(11) NOT NULL,
  `Description` varchar(250) COLLATE latin1_general_ci NOT NULL,
  `UF` varchar(2) COLLATE latin1_general_ci NOT NULL,
  `CityId` int(6) NOT NULL,
  `ZipCode` varchar(250) COLLATE latin1_general_ci NOT NULL,
  `Street` varchar(250) COLLATE latin1_general_ci NOT NULL,
  `GoogleMaps` varchar(600) COLLATE latin1_general_ci NOT NULL,
  `OpeningHours` varchar(250) COLLATE latin1_general_ci NOT NULL,
  `Type` tinyint(2) NOT NULL,
  `DisplayOrder` tinyint(2) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `addresses`
--

INSERT INTO `Addresses` (`Id`, `AdvertiserId`, `Description`, `UF`, `CityId`, `ZipCode`, `Street`, `GoogleMaps`, `OpeningHours`, `Type`, `DisplayOrder`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 2, 'Endereço da filial', 'sp', 2, '13209-010', 'Av. 9 de Julho, 1900 - Centro', '!1m18!1m12!1m3!1d3667.4754037874727!2d-46.89270288508095!3d-23.18933915384383!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cf2691ac70dbe3%3A0xf4e1101b83ef23ad!2sAv.+9+de+Julho%2C+1900+-+Centro%2C+Jundia%C3%AD+-+SP%2C+13201-019!5e0!3m2!1spt-BR!2sbr!4v1468974751106', 'De Segunda-feira à Sábado, das 08:00 às 18:00', 1, 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(2, 1, 'Endereço da concessionária', 'sp', 2, '13215-010', 'Av. Antonio Frederico Ozanan, 3837 – Bairro Vila de Vito', '!1m18!1m12!1m3!1d3667.6805019458648!2d-46.88045968508094!3d-23.18185825357186!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cf26f1f3d52fd1%3A0x155dd033a576c4ef!2sAv.+Ant%C3%B4nio+Frederico+Ozanan%2C+3837+-+Jardim+Shangai%2C+Jundia%C3%AD+-+SP!5e0!3m2!1spt-BR!2sbr!4v1468975698561', 'De Segunda à Sexta-feira, das 08:00 às 18:00, Sábado das 08:00 às 14:00', 1, 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(3, 3, 'Endereço', 'sp', 1, '07600-000', 'Est Santa Ines, 3950, Jardim Samambaia', '!1m18!1m12!1m3!1d3660.9133863080206!2d-46.66076838491964!3d-23.427495762547643!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cef0bcdea8faf7%3A0x6bd0b916ce8e46a0!2sEstr.+Santa+In%C3%AAs%2C+3950%2C+Mairipor%C3%A3+-+SP%2C+07600-000!5e0!3m2!1spt-BR!2sbr!4v1469049056112', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(4, 4, 'Endereço', 'sp', 2, '13201-002', 'Rua Marechal Deodoro da Fonseca, 984 Centro\r\n\r\n', '!1m18!1m12!1m3!1d3667.730655925989!2d-46.889633984925126!3d-23.18002855350573!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cf268bc3eaf49d%3A0x8d3108c7b0b776a9!2sR.+Mal+Deodoro+da+Fonseca%2C+984+-+Centro%2C+Jundia%C3%AD+-+SP%2C+13201-002!5e0!3m2!1spt-BR!2sbr!4v1469049513807', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(5, 5, 'Endereço', 'sp', 2, '', 'Av Comendador Gumercindo Barranqueiros, 368 (Estr. da Malota) Jd. Samambaia', '!1m18!1m12!1m3!1d3667.2839216998163!2d-46.91039218492469!3d-23.19632135409806!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cf2424256ae807%3A0x6e058f7150e4d292!2sAv.+Comendador+Gumercindo+Barranqueiros%2C+368+-+Jardim+Santa+Teresa%2C+Jundia%C3%AD+-+SP%2C+13211-410!5e0!3m2!1spt-BR!2sbr!4v1469053396621', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(6, 6, 'Endereço', 'sp', 2, '', 'Rua Major Gustavo Adolfo Storch, 26 - Anhangabaú', '!1m18!1m12!1m3!1d3667.5383224838183!2d-46.899474584925066!3d-23.187044453760766!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cf2684631f3669%3A0x868057f5a454f11a!2sR.+Maj.+Gustavo+Adolfo+Storch%2C+26+-+Vila+Virginia%2C+Jundia%C3%AD+-+SP%2C+13209-080!5e0!3m2!1spt-BR!2sbr!4v1469053532446', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(7, 7, 'Endereço', 'sp', 2, '13201-821', 'Rua Anchieta, 694 - Centro ', '!1m18!1m12!1m3!1d3667.6742300367696!2d-46.893841884925095!3d-23.182087053580556!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cf2688c69aedd9%3A0x9aaaf8b3984d886a!2sR.+Anchieta%2C+694+-+Vila+Boaventura%2C+Jundia%C3%AD+-+SP%2C+13201-804!5e0!3m2!1spt-BR!2sbr!4v1469054044506', 'De Segunda à Sexta-feira das 09h00 às 19h00 e Sábados das 09h00 às 16h00', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(8, 8, 'Endereço', 'sp', 2, '13202-252', 'Av. Samuel Martins, nº 307 – Vila Progresso', '!1m18!1m12!1m3!1d3666.9958061851125!2d-46.87074268492458!3d-23.20682345448026!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cf26d49ca56e4b%3A0x4b6f1a80b62ee42!2sAv.+Samuel+Martins%2C+307+-+Vila+Progresso%2C+Jundia%C3%AD+-+SP%2C+13202-252!5e0!3m2!1spt-BR!2sbr!4v1469054355080', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(9, 9, 'Venha nos visitar', 'sp', 2, '07600-000', 'Est Projetada, 135, Jd. Maria Eugenia, Mairipora', '!1m18!1m12!1m3!1d3664.4081315576!2d-46.56626948492252!3d-23.30094635791217!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ceedae1c3fcd81%3A0xbc229334eb54bb8d!2sR.+Projetada+Cinco%2C+Mairipor%C3%A3+-+SP%2C+07600-000!5e0!3m2!1spt-BR!2sbr!4v1469056735642', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(10, 10, 'Studio', 'sp', 2, '13209-090', 'Rua Eduardo Tomanik, 56', '!1m18!1m12!1m3!1d3667.595990731474!2d-46.898747184925064!3d-23.184941053684298!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cf26841f44ea4d%3A0xe86964603b5aea5!2sR.+Eduardo+Tomanik%2C+56+-+Ch%C3%A1cara+Urbana%2C+Jundia%C3%AD+-+SP%2C+13201-835!5e0!3m2!1spt-BR!2sbr!4v1469056845745', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(11, 11, 'Venha nos conhecer', 'sp', 2, '13206-650', 'RUA UNIÃO, 454 \r\nJUNDIAÍ', '!1m18!1m12!1m3!1d3666.851426395916!2d-46.88992928492447!3d-23.21208455467173!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cf26b4653231ab%3A0x18dfce7061976b16!2sR.+Uni%C3%A3o%2C+454+-+Parque+Uniao%2C+Jundia%C3%AD+-+SP%2C+13206-650!5e0!3m2!1spt-BR!2sbr!4v1469068830198', 'De Segunda à Sexta-feira, das 9h00 às 18h00', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(12, 11, 'Endereço Equipe de Criação', 'sp', 1, '02927-000', 'Rua Professor João Machado, 705 - bloco A - apto 62 - Freguesia do Ó', '!1m18!1m12!1m3!1d3658.9658651180653!2d-46.70708058491831!3d-23.4977389651312!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94cef8549a1980bb%3A0x4cb74e89840adbe!2sR.+Prof.+Jo%C3%A3o+Machado%2C+705+-+Nossa+Sra.+do+O%2C+S%C3%A3o+Paulo+-+SP!5e0!3m2!1spt-BR!2sbr!4v1469070890975', 'de Segunda à Sexta-feira, das 9H00 às 17h00 Sábados: 10h00 às 12h00', 2, 2, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2),
(13, 9, 'descrição', 'pe', 1, '02927-000', 'Rua Professor João Machado', 'ggggg', 'de seg à sex', 1, 1, 0, 0, '2016-07-30 00:00:00', '2016-07-30 00:00:00', 0),
(14, 5, 'descrição', 'se', 8, '35353', 'rua das portas', 'google', 'de seg à sex', 2, 1, 0, 0, '2016-07-30 00:00:00', '2016-07-30 00:00:00', 0),
(20, 12, 'Franquia Jundiaí', 'sp', 2, '2222', 'RUA BARÃO DE JUNDIAÍ, 520 - 1º E 2° ANDAR, - CENTRO', '!1m18!1m12!1m3!1d706.9985447400562!2d-46.88327658860656!3d-23.19009376926321!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x1af52213f69c355c!2sInstituto+Embelleze+Jundia%C3%AD!5e0!3m2!1spt-BR!2sbr!4v1470694348660', 'De Segunda à Sábado, das 9h00 às 18h00', 1, 1, 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `advertisers`
--

CREATE TABLE IF NOT EXISTS `Advertisers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `Code` varchar(20) COLLATE latin1_general_ci NOT NULL,
  `Name` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `Slogan` varchar(200) COLLATE latin1_general_ci NOT NULL,
  `tags` varchar(250) COLLATE latin1_general_ci NOT NULL,
  `Situation` tinyint(2) NOT NULL COMMENT '0)noInformation, 1)compliant, 2)overdue, 3)tasting, 4)blocked, 5)waitingForApproval',
  `type` tinyint(2) NOT NULL COMMENT '0)anunciante, 1)membro_destaque, 2)membro_premium, 3)membro_topSide, 4)membro_vip',
  `stripe` tinyint(2) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `advertisers`
--

INSERT INTO `Advertisers` (`Id`, `UserId`, `Code`, `Name`, `CategoryId`, `Slogan`, `tags`, `Situation`, `type`, `stripe`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 1, 'dlq2110nf', 'Mercedes Benz', 1, 'Os melhores carros, sempre!', '(jundiaí, jundiai, são paulo, sao paulo, sp, mercedes benz, autopecas) carros, automóveis, autopeças, concessionária\r\n', 1, 0, 0, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 1),
(2, 2, 'l1941ff', 'Bolo da Madre', 7, 'As nossas receitas são iguais a da sua Mama', '(jundiaí, jundiai, são paulo, sao paulo, sp, bolo da madre, salgadinhos, cafe, docinhos) , bolo, doce, salgadinho, , docinho, café', 1, 0, 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 1),
(3, 1, 'we42343', 'Arco da Serra Bar, Restaurante e Antiguidades', 3, 'Venha passar um noite regada à boa música com um incrível cardápio bem no pé da Serra', '(mairiporã, mairipora, são paulo, sp, arco da serra, bares) bar, restaurante, antiguidades, serra', 1, 0, 0, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(4, 1, 'jr55425', 'Clínica Telles Odontologia', 4, 'Os melhores sorrisos da sua vida', '(jundiaí, jundiai, sp, são paulo, Clínica Telle, Clinica Telle) dentista, odontologia, dentes, canal, bucal', 1, 0, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(5, 1, 'ywy54g', 'CNM Sport Center', 28, 'Mens sana in corpus sano', '(sp, são paulo, jundiaí, jundiai, cnm sport center, cnm) academia, treino, espeortes, gyn, personal trainer, personal', 1, 0, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(6, 1, 'safaf3535', 'Conceito Luz', 17, 'A iluminação perfeita em todos os espaços e momentos', '(sp, são paulo, jundiaí, jundiai, Conceito Luz, conceito, iluminacao, lustres, abajures) iluminação, lustre, abajur', 1, 0, 0, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(7, 1, 'af646cbcb', 'Esmalteria Nacional', 13, 'Venha passar momentos descontraídos e ainda ficar mais atraente.', '(jundiaí, jundiai, sp, são paulo, sp, Esmalteria Nacional, unhas, mãos) esmalte, unha, pedicure, mão', 1, 0, 0, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(8, 1, 'saf353dg34', 'Estética Bem Viver', 5, 'Cuidamos do seu corpo e mente', '(sp, jundiaí, jundiai, são paulo, sao paulo, Estética Bem Viver, Estetica Bem Viver, estetica) estética', 1, 0, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(9, 1, 'dsf244ff', 'Lene Fortuna - Coador de Café Individual', 29, 'Coador de Café Individual', '(sp, jundiaí, jundiai, são paulo, sao paulo, cafe, coador, Lene fortuna, coador de café individual, coador de cafe individual) café, coador, cafezinho', 1, 0, 0, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(10, 1, 'da813rdkf', 'STUDIO D´ KALI', 11, 'Cabelos incríveis, como se fossem seus', '(sp, jundiaí, jundiai, são paulo, sao paulo,STUDIO D´ KALI, sTUDIO D KALI, sTUDIO KALI, sTUDIO di KALI, sTUDIO de KALI, kali, kaly, kalli, kally, kale, kalle) cabelos, peruca, tingimento, aplique', 1, 0, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(11, 1, 'aj31jhs', 'Rosana Scott Consultoria de Image', 8, 'Plantando boas sementes para colher frutos duradouros', '(jundiaí, jundiai, são paulo, sao paulo, sp, Rosana Scott) personal Consulter, consultoria, image consulter, etiqueta, visagismo, análise cromática, estilo pessoal, auto estima, linguagem corporal, Marketing Digital Inteligente, redes sociais', 1, 0, 0, 0, 0, '0001-01-01 00:00:00', '0001-01-01 00:00:00', 1),
(12, 1, '212178jhd', 'Instituto Embelleze', 10, 'Formação Profissional', '(Instituto Embelleze, jundiaí, jundiai,sp,sao pauoo, são paulo) maquiagem', 1, 1, 1, 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `categories`
--

CREATE TABLE IF NOT EXISTS `Categories` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(250) COLLATE latin1_general_ci NOT NULL,
  `Alias` varchar(20) COLLATE latin1_general_ci NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `categories`
--

INSERT INTO `Categories` (`Id`, `Name`, `Alias`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 'Automóveis', 'automoveis', 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(2, 'Alimentação', 'alimentacao', 0, 0, '0001-01-01 00:00:00', '0001-01-01 00:00:00', 1),
(3, 'Bares e Restaurantes', 'bares_retau', 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(4, 'Odontologia', 'odonto', 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(5, 'Estética', 'estetic', 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(6, 'Lojas em geral', 'lojas_em_geral', 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(7, 'Bolo', 'bolo', 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(8, 'Consultoria Empresarial', 'consultempresarial', 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(9, 'Artesanato', 'artesanato', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(10, 'Maquiagem', 'maquiagem', 1, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(11, 'Cabelo', 'cabelo', 1, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(12, 'Pilates', 'pilates', 1, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(13, 'Manicure', 'manicure', 1, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(14, 'Pet Shop', 'petshop', 1, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(15, 'Veterinário', 'veterinario', 1, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(16, 'Móveis Planejados', 'moveisplanejados', 1, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(17, 'Decoração', 'Decoracao', 1, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(18, 'Jóias e semi – jóias', 'joiasesemi_joias', 1, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(19, 'Corretora de Seguros', 'corretoradeseguros', 1, 1, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(20, 'Lavanderia', 'lavanderia', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(21, 'Moda Roupas', 'modaroupas', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(22, 'Festa Roupas', 'festaroupas', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(23, 'Noivas Roupas', 'noivasroupas', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(24, 'Arte Galeria', 'artegaleria', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(25, 'Seguradora', 'seguradora', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(26, 'Viagem Passeios', 'viagempasseios', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(27, 'Móveis', 'moveis', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(28, 'Academia', 'academia', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(29, 'Utilidades Domésticas', 'ud', 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1);

-- --------------------------------------------------------




-- --------------------------------------------------------

--
-- Estrutura da tabela `contacts`
--

CREATE TABLE IF NOT EXISTS `Contacts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AdvertiserId` int(11) NOT NULL,
  `Ddd` varchar(10) COLLATE latin1_general_ci NOT NULL,
  `Number` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `Email` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `content` varchar(200) COLLATE latin1_general_ci NOT NULL,
  `Type` tinyint(2) NOT NULL,
  `DisplayOrder` tinyint(2) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `contacts`
--

INSERT INTO `Contacts` (`Id`, `AdvertiserId`, `Ddd`, `Number`, `Email`, `content`, `Type`, `DisplayOrder`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 1, '11', '3395-4050', 'cbmotors@cbmotors.com.br', '3395-4050', 1, 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(2, 1, '11', '4228-8360', '', '4228-8360', 10, 2, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(3, 2, '11', '4807-1818', '', '4807-1818', 1, 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(4, 3, '11', '7875-1775', '', '7875-1775', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(5, 4, '11', '4521-8849', '', '4521-8849', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(6, 3, '', '', 'andersoncoimbraf@gmail.com', 'andersoncoimbraf@gmail.com', 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(7, 5, '11', '4582 5233', '', '4582 5233', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(8, 7, '11', '4521-1212', '', '4521-1212', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(9, 7, '', '', 'sp.jundiaicentro@esmalterianacional.com.br', 'sp.jundiaicentro@esmalterianacional.com.br', 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(10, 8, '11', '4805-2622', '', '4805-2622', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(11, 8, '11', '4526-4035', '', '4526-4035', 1, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(12, 6, '11', '4497 0015', '', '4497 0015', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(13, 6, '', '', 'contato@lojaconceitoluz.com.br', 'contato@lojaconceitoluz.com.br', 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(14, 9, '11', '4604-6417', '', '4604-6417', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(15, 9, '', '', 'rosilene.fortuna@gmail.com', 'rosilene.fortuna@gmail.com', 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(16, 10, '11', '2434-2454', '', '2434-2454', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(17, 11, '11', '4807-3780', '', '4807-3780', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(18, 11, '11', '94228-7637', '', '94228-7637', 2, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(19, 11, '11', '94228-7637', '', '94228-7637', 3, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(20, 11, '', '', 'rosana@rosanascott.com', 'rosana@rosanascott.com', 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(21, 11, '', '', 'contato@rosanascott.com', 'contato@rosanascott.com', 4, 2, 0, 0, '0001-01-01 00:00:00', '2016-08-01 00:00:00', 1),
(22, 12, '11', '', '', '2449-4501', 1, 1, 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(23, 12, '', '', '', 'sp.jundiai@institutoembelleze.com', 4, 1, 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `displayorder`
--

CREATE TABLE IF NOT EXISTS `Displayorder` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Order` int(11) NOT NULL COMMENT 'ordem de exibição',
  `ShowCaseId` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='exibidor dos showCases' AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `infoes`
--

CREATE TABLE IF NOT EXISTS `Infoes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AdvertiserId` int(11) NOT NULL,
  `Text` text COLLATE latin1_general_ci NOT NULL,
  `DisplayOrder` tinyint(2) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `infoes`
--

INSERT INTO `Infoes` (`Id`, `AdvertiserId`, `Text`, `DisplayOrder`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 1, 'Criada em 2015, a CB Motors é a empresa do setor automotivo do Grupo CB. Sua estratégia de negócios prioriza a formação de um núcleo automotivo, com base em uma das marcas Premium mais reconhecidas e aspiracionais de um seleto público até consumidor: Mercedes-Benz.', 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(2, 1, 'A CB Motors oferece os melhores e mais completos serviços para o seu Mercedes Benz.', 2, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(3, 2, 'A Bolo da Madre nasceu da vontade das sócias Daniela Schiavo e Fernanda Castanheda de resgatar essa memória afetiva que marcaram a suas infâncias. Elas acreditam que o conforto de uma xícara de café e de um bolo de “vó” promovem encontros gostosos, pausas vagarosas, histórias, alegrias e fortalecem as relações humanas.', 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(4, 2, 'São mais de 30 sabores que resgataram do caderno de receitas de suas tias, mães e avós que com o principal ingrediente afeto fizeram de suas tardes as melhores lembranças que tiveram na vida.', 2, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(5, 2, 'Quem brincando no quintal numa tarde gostosa sentiu aquele cheiro delicioso de bolo no forno? E da voz mais doce que de repente, gritava ao longe “tá pronto” e todos corriam pra mesa com a boca cheia d’água?! Pois então, se existe uma lembrança de infância comum a todos nós é o aroma irresistível de bolo quentinho vindo da cozinha.', 3, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(6, 4, 'A  Telles Odontologia tem como objetivo oferecer os mais avançados tratamentos odontológicos para proporcionar a seus pacientes saúde, beleza e bem estar. Para isso, utilizamos o que há de mais moderno em equipamentos, materiais e técnicas de tratamento. Procuramos estudar as necessidades especificas de cada paciente e propor as melhores alternativas possíveis para solucionar o caso.', 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(7, 4, '<b>Especialidades</b>\r\n\r\n<ul>\r\n<li>Clínica Geral</li>\r\n<li>Endodontia (tratamento de canal)</li>\r\n<li>Periodontia (tratamento das doenças da gengiva)</li>\r\n<li>Ortodontia e Ortopedia Facial ( aparelhos fixos e removíveis)</li>\r\n<li>Cirurgia Buco-Maxilo-Facial / Ortognática Implantes</li>\r\n<li>Prótese (reabilitações)</li>\r\n<li>Odontopediatria</li>\r\n<li>Estética e Clareamento</li>\r\n<li>Disfunção Temporo-Mandibular</li>\r\n</ul>', 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(8, 5, 'O principal objetivo da CNN Sport Center é oferecer um serviço de excelência, com profissionais habilitados e devidade inscritos no Conselho Regional de Educação Física. Para pessoas de todas as idades, visando o condicionamento físico, a aprendizagem, a consiciência corporal, a performance esportiva e principalemente a melhora na qualidade de vida. Tudo em um espaço familiar bonito e agradável.\r\n', 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(9, 5, 'Modalidades:\r\nNatação\r\nMusculação\r\nSpining\r\nHidroginástica\r\nFitness\r\nFisioterapia desportiva\r\nHidroterapia\r\nJiu Jit Su\r\nZumba\r\nMat Pilates\r\nPilates\r\nHidro Spining\r\n\r\nAlém de todas essas modalidades a CNM também oferece Aero Fight, Ritmo, Fitness Ball, Avaliação Nutricional, Avaliação Física, Avaliação Médica e Drenagem Linfática.', 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(10, 6, 'Atuando há 6 anos no mercado, a CONCEITO LUZ desenvolve e executa desde o mais simples até o mais sofisticado projeto de iluminação, sempre visando as novas tendências.', 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(11, 6, 'A CONCEITO LUZ, além de possuir profissionais capacitados, também possui vários modelos de luminárias, lustres, plafons, arandelas, spots, LED’s, entre outros.', 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(12, 6, '', 0, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(13, 6, 'Para a comodidade dos clientes, a CONCEITO LUZ mantém parcerias com arquitetos, decoradores e eletricistas, o que permite uma melhor harmonia na execução dos serviços.', 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(14, 7, 'A Esmalteria Nacional é uma empresa Andare S.A. e oferece serviços diferenciados para unhas, mãos e pés. Na esmalteria você encontra desde técnicas tradicionais até as mais modernas para o cuidado, recuperação e customização das unhas, além de serviços adicionais como podologia e quick massage.\r\n\r\nTodos os serviços são executados por profissionais treinadas que utilizam equipamentos de última geração, materiais esterilizados, utensílios descartáveis e diversos esmaltes, nacionais e importados.', 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(15, 3, 'Um lugar para se reviver o passado!\r\n\r\nMussum Ipsum, cacilds vidis litro abertis. Posuere libero varius. Nullam a nisl ut ante blandit hendrerit. Aenean sit amet nisi. Cevadis im ampola pa arma uma pindureta. Si u mundo tá muito paradis? Toma um mé que o mundo vai girarzis! Detraxit consequat et quo num tendi nada.', 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(16, 8, 'A Estética Bem Viver foi pensada e criada pela  Dra Elisângela Ribas , com  formação de Esteticista, Biológa e Biomédica. É especialista em acupuntura sistêmica e auricular, analises clinicas e biomedicina estética e professora da Universidade Anchieta no curso de Estética e Cosmética.', 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(17, 8, 'Atuando nesta área desde 1990, a profissional dedicou parte de seus estudos ao tema eletroestimulação neuromuscular  e desenvolveu pesquisa na qual provou a eficácia do tratamento por meio de resultados comprovados de redução de medidas.', 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(18, 8, 'A Estética Bem Viver é composta por um equipe altamente qualificada  de Tecnólogo de Estética, Esteticista, Farmaceuticos, Educadores Fisícos , Nutricionistas, Massoterapeutas  e  Fisioterapêutas', 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(19, 8, 'A Estética Bem Viver oferece todo tipo de tratamento para te deixar bonita e, consequentemente, satisfeita com seu corpo e saudável.\r\n\r\nTudo o que você precisa para se sentir bem e feliz A Estética Bem Viver tem para você', 4, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(20, 9, 'Quem nós somos?\r\nNós da Lene Fortuna Arts somos uma equipe dedicada a fazer do seu simples cafezinho  mais que um simples hábito, tornar este momento uma experiência  de sabor inesquecível. Deixe-se esquecer dos problemas do dia-a-dia relaxando  na companhia de amigos, família ou aquela pessoa especial que você tanto ama.\r\nCada um dos membros altamente capacitados na montagem do Coador de Café Individual não tem outro objetivo que não seja agradá-lo e fazê-lo sentir-se bem ao  degustar do melhor do café. ', 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(21, 10, 'Mussum Ipsum, cacilds vidis litro abertis. Posuere libero varius. Nullam a nisl ut ante blandit hendrerit. Aenean sit amet nisi. Cevadis im ampola pa arma uma pindureta. Si u mundo tá muito paradis? Toma um mé que o mundo vai girarzis! Detraxit consequat et quo num tendi nada.', 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(22, 11, 'Seu Estilo e sua Imagem são responsáveis pela sua comunicação não verbal.... Análise de Personalidade (auto estima), Comportamento (linguagem corporal), Postura (etiqueta), Visagismo (estudo do rosto), Analise Cromática (estudo das cores para a sua própria pele) e Estilo Pessoal.', 1, 0, 0, '0001-01-01 00:00:00', '2016-08-01 00:00:00', 0),
(23, 11, 'Sou proprietária da empresa “RS Rosana Scott – Marketing Digital Inteligente” aonde realizo juntamente com a minha equipe Consultorias, Palestras, Eventos, Treinamentos, Apresentadora, entre outros serviços para que a sua imagem pessoal ou de sua empresa sejam representadas de forma perfeita. Tenho formas objetivas e estratégicas a em divulgação, bem como os objetivos e atividades para o resultado de sucesso que serão colhidos hoje e amanhã.', 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(25, 12, 'Sapien in monti palavris qui num significa nadis i pareci latim. Mais vale um bebadis conhecidiss, que um alcoolatra anonimiss. in elementis mé pra quem é amistosis quis leo. Cevadis im ampola pa arma uma pindureta.', 1, 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `media`
--

CREATE TABLE IF NOT EXISTS `Media` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AdvertiserId` int(11) NOT NULL,
  `FileName` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `URL` varchar(500) COLLATE latin1_general_ci NOT NULL,
  `title` varchar(200) COLLATE latin1_general_ci NOT NULL,
  `Description` text COLLATE latin1_general_ci NOT NULL,
  `Type` tinyint(2) NOT NULL,
  `DisplayOrder` tinyint(2) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `media`
--

INSERT INTO `Media` (`Id`, `AdvertiserId`, `FileName`, `URL`, `title`, `Description`, `Type`, `DisplayOrder`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 1, 'logo_MercedesBenz.png', '', '0', 'logo', 3, 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(2, 2, 'logo_BoloDaMadre.png', '', '0', 'logo', 3, 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(3, 1, 'mercedes.jpg', '', '0', 'imagem dos detalhes', 1, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(4, 2, 'boloDaMadre.jpg', '', '0', 'imagem dos detalhes', 1, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(5, 1, '16c47_03.jpg', '', '0', 'painel do mercedão', 7, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(6, 1, 'mercedes-benz-glc-2.jpeg', '', '0', 'picup', 7, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(7, 1, 'Mercedes-Benz-GLC-class1.jpg', '', '0', 'Mercedes-Benz-GLC', 7, 3, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(8, 2, 'boloDaMama1.jpg', '', '0', 'bolo de maçã', 7, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(9, 2, 'boloDaMama2.jpg', '', '0', 'bolo de alguma coisa', 7, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(10, 2, 'boloDaMama3.jpg', '', '0', 'bolo de chocolate', 7, 3, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(11, 1, '', 'https://www.youtube.com/embed/cfTTTFnWDK0?autoplay', '0', 'vídeo by Rosana Scott to Mercedes Benz', 9, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(12, 2, '', 'https://www.youtube.com/embed/VC_8RJA-mRU?autoplay', '0', 'vídeo by Rosana Scott to Bolo da Madre', 9, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(13, 1, 'php8kze8p.jpg', '', '0', 'mercedes vermelho ferrari ', 7, 4, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(14, 1, 'mercedes22.jpg', '', '0', 'painel frontal com o símbolo', 7, 5, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(15, 1, 'MTM4ODAwODU2OTk5OTI5NzMw.jpg', '', '0', 'descrição thumbnail 2', 5, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(16, 1, 'mercedes-benz-gle-c292_start_1000x470_03-2015.jpg', '', '0', 'descrição thumbnail 3', 5, 3, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(17, 1, 'Mercedes-Benz-CarPlay-2016.jpg', '', '0', 'mini mercedes', 5, 4, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(18, 2, 'boloDaMama4.jpg', '', '0', 'bolo 2', 5, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(19, 2, 'boloDaMama5.jpg', '', '0', 'bolo 3', 5, 3, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(20, 2, 'boloDaMama6.jpg', '', '0', 'bolo 4', 5, 5, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(21, 3, 'logo_arcoDaSerra.png', '', '0', '', 3, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(22, 3, 'arco.jpg', '', '0', '', 7, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(23, 3, 'arco2.jpg', '', '0', '', 7, 2, 2, 2, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(24, 3, 'arco3.jpg', '', '0', '', 7, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(25, 3, 'arco4.jpg', '', '0', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(26, 3, 'arco5.jpg', '', '0', '', 7, 5, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(27, 3, 'arco5.jpg', '', '0', '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(28, 3, 'arco6.jpg', '', '0', '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(29, 3, 'arco2.jpg', '', '0', '', 5, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(30, 4, 'logo_clinicaTelles.png', '', '0', '', 3, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(31, 4, 'implantesdentarios.jpg', '', '0', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(32, 4, 'phoca_thumb_l_Fachada1.JPG', '', '0', '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(33, 4, 'phoca_thumb_l_Consultorio1.JPG', '', '0', '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(34, 4, 'phoca_thumb_l_Consultorio2.JPG', '', '0', '', 5, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(35, 4, 'phoca_thumb_l_Consultorio1.JPG', '', '0', '', 7, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(36, 4, 'phoca_thumb_l_Consultorio2.JPG', '', '0', '', 7, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(37, 4, 'phoca_thumb_l_Fachada1.JPG', '', '0', '', 7, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(38, 4, 'phoca_thumb_l_Recepcao.JPG', '', '0', '', 7, 4, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(39, 5, 'logo_cnnSportCenter.png', '', '0', '', 3, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(40, 6, 'logo_Conceito.png', '', '0', '', 3, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(41, 7, 'logo_EsmalteriaNacional.png', '', '0', '', 3, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(42, 8, 'logo_EsteticaBemViver.png', '', '0', '', 3, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(43, 9, 'logo_LeneFortuna.png', '', '0', '', 3, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(44, 10, 'logo_StudioDKali.png', '', '0', '', 3, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(45, 5, 'Cnm2.JPG', '', '0', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(46, 5, 'Cnm3.JPG', '', '0', '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(47, 5, 'Cnm4.JPG', '', '0', '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(48, 5, 'Cnm1.JPG', '', '0', '', 5, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(49, 5, 'Cnm1.JPG', '', '0', '', 7, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(50, 5, 'Cnm4.JPG', '', '0', '', 7, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(51, 5, 'cnm2b.jpg', '', '0', '', 7, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(52, 5, 'cnm3b.jpg', '', '0', '', 7, 4, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(53, 5, 'cnm5.jpg', '', '0', '', 7, 5, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(54, 6, 'chamada001.jpg', '', '0', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(55, 6, 'chamada002.jpg', '', '0', '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(56, 6, 'chamada003.jpg', '', '0', '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(57, 6, 'chamada004.jpg', '', '0', '', 5, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(58, 6, 'chamada005.jpg', '', '0', '', 7, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(59, 6, 'chamada006.jpg', '', '0', '', 7, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(60, 6, 'chamada007.jpg', '', '0', '', 7, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(61, 7, 'download.jpg', '', '0', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(62, 7, 'download (1).jpg', '', '0', '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(63, 7, 'esmalte.jpg', '', '0', '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(64, 7, 'esmalteria3.jpg', '', '0', '', 5, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(65, 7, 'Slide3.jpg', '', '0', '', 7, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(66, 7, 'esmalte.jpg', '', '0', '', 7, 2, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(67, 8, 'Plano31424.jpg', '', '0', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(68, 8, 'post4242.jpg', '', '0', '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(69, 8, 'post_pilates.png', '', '0', '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(70, 8, 'post4242.jpg', '', '0', '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(71, 8, 'post4242.jpg', '', '0', '', 7, 1, 1, 1, '2016-07-20 00:00:00', '0000-00-00 00:00:00', 2),
(72, 8, 'Plano31424.jpg', '', '0', '', 7, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(73, 9, 'coador-de-cafe-individual.jpg', '', '0', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(74, 9, 'coador-individual-kit-com-canecas-cafe.jpg', '', '0', '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(75, 9, 'coador-individual-ref-200-cafe.jpg', '', '0', '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(76, 9, 'coador-individual-ref-2013-coador-indivual.jpg', '', '0', '', 5, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(77, 9, 'coador-individual-ref-2013-coador-indivual.jpg', '', '0', '', 7, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(78, 9, 'coador-individual-ref-200-cafe.jpg', '', '0', '', 7, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(79, 10, 'studioDKali4.jpg', '', '0', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(80, 10, 'studioDKali2.jpg', '', '0', '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(81, 10, 'studioDKali3.jpg', '', '0', '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(82, 10, 'studioDKali4.jpg', '', '0', '', 5, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(83, 10, 'studioDKali4.jpg', '', '0', '', 7, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(84, 10, 'studioDKali2.jpg', '', '0', '', 7, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(85, 10, 'studioDKali.jpg', '', '0', '', 7, 4, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(86, 11, 'portifolio-guardaRoupas.png', '', '0', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(87, 11, 'portifolio-cromatismo.png', '', '0', '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(88, 11, 'portifolio-shopper.png', '', '0', '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(89, 11, 'portifolio-estilo.png', '', '0', '', 5, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(90, 11, 'rs-logo.png', '', '0', '', 3, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(91, 11, 'portifolio2.png', '', '0', 'Apresentadora / Modelo', 7, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(92, 11, 'portifolio11.png', '', '0', 'Consultoria de Imagem', 7, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(93, 11, 'portifolio8.png', '', '0', 'Divulgação / Eventos', 7, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(94, 11, 'portifolio12.png', '', '0', '', 7, 4, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2),
(95, 11, 'portifolio8.png', '', '0', 'descrição', 2, 1, 11, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(96, 11, 'portifolio-visagismo.png', '', '0', '', 4, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(97, 11, 'portifolio-cromatismo.png', '', '0', '', 6, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(98, 11, 'portifolio-shopper.png', '', '0', '', 6, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(99, 5, 'videoplayback.mp4', '', '0', '', 8, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(100, 11, 'videoplayback2.mp4', '', '0', '', 8, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(102, 11, 'Alfaiataria Namastê', 'https://www.youtube.com/embed/EitAhMQK4CA', '0', 'youtube - DICAS by ROSANA SCOTT essa Semana \r\n\r\nMussum Ipsum, cacilds vidis litro abertis. Detraxit consequat et quo num tendi nada. Não sou faixa preta cumpadi, sou preto inteiris, inteiris. Praesent vel viverra nisi. Mauris aliquet nunc non turpis scelerisque, eget. Suco de cevadiss deixa as pessoas mais interessantiss.', 9, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(103, 11, '', 'https://player.vimeo.com/video/164562375?portrait=0&badge=0', '0', 'vimeo', 10, 10, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(104, 11, 'apostila2.pdf', '', '0', 'pdf', 12, 11, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(105, 11, '', 'https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/43523493&amp;auto_play=false&amp;hide_related=false&amp;show_comments=true&amp;show_user=true&amp;show_reposts=false&amp;visual=true', '0', 'Waters Of March', 16, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(106, 11, '', 'https://www.youtube.com/embed/jZlNPkTVkvg', '0', 'Alfaiataria Namaste - Trajes Masculinos', 9, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(107, 12, 'logo_embelleze.jpg', '', 'logo', '', 3, 1, 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1),
(108, 12, 'Instituto-Embelleze-Cursos-Embelleze-4.jpg', '', '', '', 1, 1, 1, 1, '2016-08-08 00:00:00', '2016-08-08 00:00:00', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `messages`
--

CREATE TABLE IF NOT EXISTS `Messages` (
  `Id` int(11) NOT NULL,
  `EmailSender` varchar(100) NOT NULL,
  `EmailFrom` varchar(100) NOT NULL,
  `EmailTo` varchar(100) NOT NULL,
  `EmailTo2` varchar(100) NOT NULL,
  `EmailToCc` varchar(100) NOT NULL,
  `AdvertiserId` int(11) NOT NULL,
  `Type` tinyint(2) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Tel` varchar(100) NOT NULL,
  `Message` text NOT NULL,
  `Subject` varchar(100) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='armazena as mensagens entre os visitantes, anunciantes e os adm do site';

-- --------------------------------------------------------

--
-- Estrutura da tabela `paymentmethods`
--

CREATE TABLE IF NOT EXISTS `Paymentmethods` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AdvertiserId` int(11) NOT NULL,
  `Name` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `Type` tinyint(2) NOT NULL,
  `DisplayOrder` tinyint(2) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `paymentmethods`
--

INSERT INTO `Paymentmethods` (`Id`, `AdvertiserId`, `Name`, `Type`, `DisplayOrder`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 1, 'dinheiro', 1, 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(2, 1, 'boleto', 2, 2, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(3, 1, 'cartão visa', 3, 3, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(4, 1, 'cartão master card', 4, 4, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(5, 2, 'dinheiro', 1, 1, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(6, 2, 'vale alimentação - alelo', 9, 2, 1, 1, '2016-07-18 00:00:00', '2016-07-18 00:00:00', 2),
(7, 3, '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(8, 3, '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(9, 4, '', 6, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(10, 5, '', 7, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(11, 6, '', 9, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(12, 7, '', 8, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(13, 7, '', 4, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(14, 8, '', 5, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(15, 9, '', 2, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(16, 9, '', 4, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(17, 10, '', 2, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(18, 10, '', 7, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(19, 11, '', 1, 1, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2),
(20, 11, '', 2, 2, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2),
(21, 11, '', 3, 3, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2),
(22, 11, '', 4, 4, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2),
(23, 11, '', 5, 5, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2),
(24, 11, '', 6, 6, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2),
(25, 11, '', 7, 7, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2),
(26, 11, '', 8, 8, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2),
(27, 11, '', 9, 9, 1, 1, '2016-07-21 00:00:00', '2016-07-21 00:00:00', 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `ratings`
--

CREATE TABLE IF NOT EXISTS `Ratings` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AdvertiserId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `rate` tinyint(1) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `ratings`
--

INSERT INTO `Ratings` (`Id`, `AdvertiserId`, `UserId`, `rate`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 1, 1, 3, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(2, 2, 1, 4, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(3, 2, 2, 5, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(4, 2, 2, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(5, 1, 3, 4, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(6, 2, 4, 5, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(7, 1, 5, 3, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(8, 2, 5, 4, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(9, 3, 1, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(10, 3, 1, 5, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(11, 4, 1, 5, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(12, 4, 1, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(13, 4, 1, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(14, 5, 1, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(15, 5, 1, 4, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(16, 5, 1, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(17, 6, 1, 4, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(18, 8, 1, 3, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(19, 10, 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(20, 10, 1, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(21, 11, 1, 4, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(22, 11, 1, 3, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(23, 11, 1, 5, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(24, 11, 1, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(25, 11, 1, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(26, 11, 1, 3, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(27, 11, 1, 5, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `ShowCaseAdvertisers`
--

CREATE TABLE IF NOT EXISTS `ShowCaseAdvertisers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ShowCaseId` int(11) NOT NULL,
  `AdvertiserId` int(11) NOT NULL,
  `DisplayOrder` int(2) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COMMENT='lista com vitrines e anunciantes' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `showcaseadvertisers`
--

INSERT INTO `ShowCaseAdvertisers` (`Id`, `ShowCaseId`, `AdvertiserId`, `DisplayOrder`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 1, 3, 4, 0, 0, '2016-07-31 00:00:00', '2016-07-31 00:00:00', 1),
(2, 1, 7, 4, 0, 0, '2016-07-31 00:00:00', '2016-07-31 00:00:00', 1),
(3, 2, 11, 3, 0, 0, '2016-07-31 00:00:00', '2016-07-31 00:00:00', 1),
(4, 2, 6, 3, 0, 0, '2016-07-31 00:00:00', '2016-07-31 00:00:00', 1),
(5, 2, 8, 3, 0, 0, '2016-07-31 00:00:00', '2016-07-31 00:00:00', 1),
(6, 3, 1, 5, 0, 0, '2016-07-31 00:00:00', '2016-07-31 00:00:00', 1),
(7, 3, 2, 5, 0, 0, '2016-07-31 00:00:00', '2016-07-31 00:00:00', 1),
(8, 3, 4, 5, 0, 0, '2016-07-31 00:00:00', '2016-07-31 00:00:00', 1),
(9, 3, 11, 5, 0, 0, '2016-07-31 00:00:00', '2016-07-31 00:00:00', 1),
(10, 3, 8, 5, 0, 0, '2016-07-31 00:00:00', '2016-07-31 00:00:00', 1),
(11, 4, 1, 6, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(12, 4, 2, 6, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(13, 4, 3, 6, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(14, 4, 4, 6, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(15, 4, 5, 6, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(16, 4, 6, 6, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(17, 4, 7, 6, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(18, 4, 8, 6, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(19, 4, 9, 6, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(20, 4, 10, 6, 0, 0, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(21, 5, 9, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(22, 5, 7, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(23, 5, 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(24, 5, 3, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(25, 5, 1, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(26, 6, 2, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(27, 6, 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(28, 6, 6, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(29, 6, 8, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(30, 6, 10, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(31, 2, 7, 3, 1, 1, '2016-08-13 00:00:00', '2016-08-13 00:00:00', 1),
(32, 2, 4, 3, 1, 1, '2016-08-13 00:00:00', '2016-08-13 00:00:00', 1),
(33, 2, 10, 3, 1, 1, '2016-08-13 00:00:00', '2016-08-13 00:00:00', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `showcases`
--

CREATE TABLE IF NOT EXISTS `ShowCases` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Alias` varchar(10) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` text NOT NULL,
  `Title` varchar(30) NOT NULL COMMENT '<h1>',
  `SubTitle` varchar(30) NOT NULL COMMENT '<h2>',
  `TotalOfAdvertising` int(2) NOT NULL,
  `ShowCaseType` tinyint(2) NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `Image` varchar(250) NOT NULL,
  `ControllerView` varchar(100) NOT NULL,
  `Parameter1` varchar(30) NOT NULL,
  `Parameter2` varchar(30) NOT NULL,
  `Parameter3` varchar(30) NOT NULL,
  `background_color` varchar(100) NOT NULL COMMENT 'cor de fundo',
  `text_color` varchar(100) NOT NULL COMMENT 'cor do texto',
  `Width` int(4) NOT NULL,
  `sectionId` varchar(100) NOT NULL COMMENT 'nome da div/section',
  `Height` int(4) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COMMENT='parametrização das vitrines' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `showcases`
--

INSERT INTO `ShowCases` (`Id`, `Alias`, `Name`, `Description`, `Title`, `SubTitle`, `TotalOfAdvertising`, `ShowCaseType`, `CategoryId`, `Image`, `ControllerView`, `Parameter1`, `Parameter2`, `Parameter3`, `background_color`, `text_color`, `Width`, `sectionId`, `Height`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 'topPage', 'topPage', 'grid de anuncios no topo do site', '', '', 2, 1, 0, '', '~/Views/Advertisers/ListPartialView.cshtml', '', '', '', '', '', 0, '', 0, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(2, 'destaques', 'destaques', 'destaques', 'destaques', 'os anunciantes preferidos dos ', 3, 3, 0, '', '~/Views/Advertisers/ListPartialView.cshtml', '', '', '', '', '', 0, '', 0, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(3, 'carousel2', 'carousel2 single com imagem e texto', '~/Views/_partialViews/showCases/_display_carouselImageAndText_single.cshtml', 'os mais acessados xx xx', 'nos meses de junho e julho xx ', 10, 5, 1, '', '~/Views/_partialViews/showCases/_display_carouselImageAndText_single.cshtml', '', '', '', '', '', 0, 'carousel2', 0, 1, 1, '0001-01-01 00:00:00', '2016-07-31 00:00:00', 1),
(4, 'carousel1', 'carousel sem filtro', 'cagegoria1', 'Promoções', 'várias promoções disponíveis', 12, 3, 0, '', '~/Views/_partialViews/showCases/_display_carouselOneLine.cshtml', '', '', '', '', '', 0, '', 0, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 1),
(5, 'grd', 'carouselWithFilter', 'grid', 'Bolos, bares e restaurantes', '03-ago', 4, 4, 0, '', '~/Views/_partialViews/showCases/_display_carouselOneLine_withFilter.cshtml', '', '', '', 'white', 'black', 0, 'carouselWithFilter', 0, 1, 1, '2016-08-03 00:00:00', '2016-08-03 00:00:00', 1),
(6, 'vip', 'galeria vip', 'empresas de destaque', 'Galeria VIP', 'empresas de destaque', 6, 14, 0, '', '~/Views/_partialViews/showCases/_display_carouselImageAndTitlesOnly_triple.cshtml', '', '', '', '#663399', 'white', 0, 'vipArea', 0, 1, 1, '2016-08-03 00:00:00', '2016-08-03 00:00:00', 1);

-- --------------------------------------------------------

--
-- Estrutura da tabela `socialmedias`
--

CREATE TABLE IF NOT EXISTS `SocialMedias` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `AdvertiserId` int(11) NOT NULL,
  `URL` varchar(250) COLLATE latin1_general_ci NOT NULL,
  `Account` varchar(250) COLLATE latin1_general_ci NOT NULL,
  `Description` varchar(250) COLLATE latin1_general_ci NOT NULL,
  `Type` tinyint(2) NOT NULL,
  `DisplayOrder` tinyint(2) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `socialmedias`
--

INSERT INTO `SocialMedias` (`Id`, `AdvertiserId`, `URL`, `Account`, `Description`, `Type`, `DisplayOrder`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 2, 'http://bolodamadre.com.br/', '', '', 1, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(2, 1, 'http://www.cbmotors.com.br/', '', '', 1, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(3, 1, 'https://www.facebook.com/CB-Motors-Mercedes-1191143071001403/?ref=ts&fref=ts', '', '', 4, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(4, 1, 'https://www.instagram.com/cb.motors/', '', '', 6, 3, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(5, 2, 'https://www.facebook.com/BolodaMadre/', '', '', 4, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(6, 2, 'https://www.instagram.com/bolodamadre/', '', '', 6, 3, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(10, 4, 'http://www.tellesodonto.com.br/', '', 'site', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(11, 5, 'http://academiacnm.com.br/index.html', '', 'site', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(12, 5, 'https://www.facebook.com/AcademiaCnmSportCenter', '', '', 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(13, 6, 'http://www.lojaconceitoluz.com.br/site/index.php', '', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(14, 6, 'https://www.facebook.com/conceitoluz', '', '', 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(15, 8, 'https://www.facebook.com/esteticabemviver', '', '', 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(16, 8, 'https://twitter.com/bemviverjundiai', '', '', 5, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(17, 8, 'https://www.instagram.com/esteticabemviver/', '', '', 6, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(18, 8, 'https://www.youtube.com/channel/UCoXtLXI1asC40kHfyo5PWCQ', '', '', 7, 4, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(19, 8, 'http://www.esteticabemviver.com.br/', '', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(20, 7, 'http://www.esmalterianacional.com.br/', '', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(21, 7, 'https://www.facebook.com/EsmalteriaNacional?fref=ts', '', '', 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(22, 7, 'https://www.instagram.com/esmalterianacional/', '', '', 6, 2, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(23, 10, 'https://www.facebook.com/Studio-d-Kali-514358005278554/', '', '', 4, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(24, 9, 'https://plus.google.com/101877014098131478437/posts', '', '', 8, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(25, 9, 'http://coadordecafeindividual.blogspot.com.br/2013/03/suporte-e-xicaras-com-design-moderno.html', '', '', 1, 1, 1, 1, '2016-07-20 00:00:00', '2016-07-20 00:00:00', 2),
(27, 11, 'http://www.rosanascott.com/blog', '', 'blog', 2, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(31, 11, 'https://www.instagram.com/rosana_scott/', '', 'visitem o meu instagram', 6, 6, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(33, 11, 'https://plus.google.com/+RosanaScott/posts', '', 'minha página no google+', 8, 8, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(34, 11, 'https://www.linkedin.com/in/rosanascott', '', 'veja o meu perfil no linkedin', 9, 9, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(36, 11, 'http://www.rosanascott.com/', '', 'conheça o meu site', 1, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(37, 0, 'http://www.rosanascott.com/blog', '', 'veja o meu blog', 2, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(39, 11, 'https://www.facebook.com/ImageConsultancyandPersonalStylist', '', 'face ImageConsultancyandPersonalStylist', 4, 4, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(40, 11, 'https://mobile.twitter.com/ScottRosana?p=s', '', 'esse é o meu twitter', 5, 5, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(42, 11, 'https://www.youtube.com/channel/UCJW4-MifkJVtBZmJ_xaO_kw', '', 'conheça o meu canal no youtube', 7, 7, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(45, 11, 'https://vimeo.com/', '', 'vimeo', 10, 10, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(46, 11, 'https://br.pinterest.com/rosanascott/', '', 'pinterest', 11, 11, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(47, 11, 'https://www.flickr.com/', '', 'flickr', 12, 12, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(48, 11, 'https://myspace.com/', '', 'mySpace', 13, 13, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(49, 11, 'https://soundcloud.com/soundcloud', '', 'soundCloud', 14, 14, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tagadvertisers`
--

CREATE TABLE IF NOT EXISTS `TagAdvertisers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TagId` int(11) NOT NULL,
  `AdvertiserId` int(11) NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `tagadvertisers`
--

INSERT INTO `TagAdvertisers` (`Id`, `TagId`, `AdvertiserId`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 1, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(2, 2, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(3, 3, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(4, 4, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(5, 5, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(6, 6, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(7, 6, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(8, 7, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(9, 7, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(10, 8, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(11, 9, 1, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2),
(12, 10, 2, 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 2);

-- --------------------------------------------------------

--
-- Estrutura da tabela `tags`
--

CREATE TABLE IF NOT EXISTS `Tags` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TagText` varchar(50) COLLATE latin1_general_ci NOT NULL,
  `AddUserId` int(11) NOT NULL,
  `UpdateUserId` int(11) NOT NULL,
  `AddDate` datetime NOT NULL,
  `UpdateDate` datetime NOT NULL,
  `St` tinyint(2) NOT NULL COMMENT 'opções: 0)noInformation,1)disabled, 2)activated, 3)blocked, 4)newness, 5)comingSoon, 6)concluded, 7)waitingForApproval',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci COMMENT='database Rosana Scott Indica' AUTO_INCREMENT=1 ;

--
-- Extraindo dados da tabela `tags`
--

INSERT INTO `Tags` (`Id`, `TagText`, `AddUserId`, `UpdateUserId`, `AddDate`, `UpdateDate`, `St`) VALUES
(1, 'bolo', 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 1),
(2, 'doce', 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 1),
(3, 'visagismo', 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 1),
(4, 'redes sociais', 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 1),
(5, 'automóveis', 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 1),
(6, 'concessionária', 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 1),
(7, 'autopeça', 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 1),
(8, 'academia', 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 1),
(9, 'cabelo', 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 1),
(10, 'unha', 1, 1, '2016-07-19 00:00:00', '2016-07-19 00:00:00', 1),
(11, 'peruca', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(12, 'personal trainer', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(13, 'iluminação', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(14, 'café', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(15, 'coador', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(16, 'bar', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(17, 'restaurante', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(18, 'odontologia', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(19, 'estética', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(20, 'esmalte', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1),
(21, 'podóloga', 0, 0, '0000-00-00 00:00:00', '0000-00-00 00:00:00', 1);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
