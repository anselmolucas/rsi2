using rsi.Entities.AdvertiserDetails;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rsi.Entities
{
    /// <summary>
    /// tabela usada para configurar as vitrines a serem exibidas no frontEnd, nesse momento todas as vitrines serão do tipo carousel com ou sem filtros. Através dessa tabela será possível definir quais registros (anunciantes) serão exibidos, a ordem de exibição das vitrines, quantos registros cada vitrine irá apresentar, título / subtítulo, cor de fundo, etc... obs.: só serão exibidos registros de anunciantes com st="on"
    /// </summary>
    public class Display : Auxiliar
    {
        /* -------------------------------------------------------------------------------------
           informações de identificação da display
        ------------------------------------------------------------------------------------- */
        #region identity 
        [Key]
        [DisplayName("id")]
        public int Id { get; set; }

        /// <summary>
        /// nome curto / apelido da vitrine de no máximo 10 caracteres 
        /// </summary>
        [DisplayName("apelido")]
        public string Alias { get; set; }

        /// <summary>
        /// título, nome da display 
        /// </summary>
        [DisplayName("nome da display")]
        public string Name { get; set; }

        /// <summary>
        /// instruções de uso e objetivos da vitrine, por exemplo: lista vip de anunciantes, restaurantes, anunciantes em oferta, etc
        /// </summary>
        [DisplayName("objetivos")]
        public string Objectives { get; set; }

        /// <summary>
        /// icon da vitrine
        /// </summary>
        [DisplayName("ícone")]
        public string MediaFileName { get; set; }

        /// <summary>
        /// local de exibição da display (notSet, home, sideBar, header, footer, advertiserDetails, searchResult, otherPages)
        /// </summary>
        [DisplayName("local de exibição")]
        public display_local LocalDisplay { get; set; }

        /// <summary>
        /// 0)notSet (não definido), 1)showCase (display do anunciante), 2)advertising (anúncio), 
        /// 3)widget(menu de categorias por icons / imagens, search, tagsCloud, etc), 
        /// 4)section(aboutUs, contact, etc)
        /// </summary>
        [DisplayName("tipo de display")]
        public display_type Display_type { get; set; }
        #endregion

        /* -------------------------------------------------------------------------------------
           informações de configuração 
        ------------------------------------------------------------------------------------- */
        #region info
        /// <summary>
        /// seleção do campo a ser usado como critério de seleção automática de registros 
        /// através das opções categoryId, subCategoryId, tags, stripe e cityId
        /// se aopção for "toDefine" ou "tags", "stripe" ou "cityId", será necessário indicar o campo ou critério em "FieldToSselectRecords_criterion"
        /// se definido como seleção "manual", o usuário irá separar manualmente cada anunciante        
        /// </summary>
        [DisplayName("selecionar critério")]
        public fieldToSselectRecords_criterion FieldToSselectRecords_criterionSelect { get; set; }

        /// <summary>
        /// nome do campo da tabela Advertisers usado para a separação automática de registros (separação automática por automaticByField)
        /// </summary>
        [DisplayName("campo de critério")]
        public string FieldToSselectRecords_criterion { get; set; }

        /// <summary>
        /// valor/conteúdo/informãção que será pesquisado automáticamente para separar registros de acordo com o campo definido (CriteriaFieldToSselectRecords)
        /// </summary>
        [DisplayName("valor de critério")]
        public string FieldToSselectRecords_criterionValue { get; set; }

        /// <summary>
        /// número máximo de registros, se for zero pegará todos os registros que atenderem à condição, senão for zero, usará a instrução linq "take(n)" e mostrará o número de registros determinado (importante lembrar do cirtério de classificação de registros "sortBy")
        /// </summary>
        [DisplayName("max registros")]
        public int MaximumNumberOfRecords { get; set; }

        /// <summary>
        /// ligar / desligar a exibição de registros de ordem aleatória 01(aleatória ligado) ou 0 (aleatória desligado)
        /// </summary>
        [DisplayName("exibição aleatória")]
        public bool DisplayListInRandomOrder { get; set; }

        /// <summary>
        /// campo da tabela advertiser que definirá a ordem de exibição dos registros (sortBy)
        /// </summary>
        [DisplayName("campo de sort")]
        public string SortRegisters_criterion { get; set; }

        /// <summary>
        /// será usado para separar os anunciantes por categoria (separação automática por categoryId)
        /// </summary>
        [DisplayName("categoria")]
        public int CategoryId { get; set; }

        /// <summary>
        /// será usado para separar os anunciantes por subCategoria (separação automática por subCategoryId)
        /// </summary>
        [DisplayName("subCategoria")]
        public int SubCategoryId { get; set; }

        

        [DisplayName("cidade")]
        public int CityId { get; set; }

        /// <summary>
        /// modelo de vitrine a ser usada, opções: noInformation, metro, list, listWithFilter, grid, gridWithFilter, gridCarousel, gridCarouselWithFilter, slider_single, slider_double, slider_triple, ad_single, ad_double, ad_triple, vip
        /// </summary>
        [DisplayName("modelo de showCase de anunciantes")]
        public showCase_model ShowCase_model { get; set; }

        /// <summary>
        /// define qual imagem do anunciantes será usada na vitrine, por exemplo podemos optar por exibir na vitrine o logo ou a imagem
        /// principal do anunciante (notSet, logo, image, slider, carousel, youtube, vimeo, soundCloud, url) o enum "mediaType" está em rsi.Entities.AdvertiserDetails.media
        /// </summary>
        [DisplayName("tipo de media a ser usada no showCase")]
        public showCaseMedia_select ShowCaseMedia_selected { get; set; }

        /// <summary>
        /// modelo de aúncio: noInformation, image_single, slider, carousel, image_double, image_triple, image_quadruple
        /// </summary>
        [DisplayName("modelo de anúncio")]
        public advertising_model Advertising_model { get; set; }

        /// <summary>
        /// endereço da view ou partial view a ser usada para a vitrine (ShowCaseType) escolhido
        /// </summary>
        [DisplayName("view path")]
        public string ViewPath { get; set; }

        /// <summary>
        /// define automaticamente qual view (partial view ou action/controller) usar:a_definir, categoriesMenu, categoriesMenu_sideBar, TagsCloud_sidebar, google_AdWords_sidebar, google_AdWords, toDefineUrlPath
        /// </summary>
        [DisplayName("modelo de widget")]
        public widgetModel Widget_model { get; set; }

        /// <summary>
        /// define automaticamente qual view (partial view ou action/controller) usar:a_definir, contact, contact_sideBar, ourTeam, ourNumbers, whoWeAred, aboutUs, welcome, whyAdvertiseHere, youWantToAdvertiseHe, toDefineUrlPath
        /// </summary>
        [DisplayName("modelo de seção")]
        public sectionModel Section_model { get; set; }

        /// <summary>
         /// textos usados para filtrar o anunciante em showcases com filtro (colocar palavras separadas por vírgulas)
         /// </summary>
        [DisplayName("filtros de seleção")]
        public string FilterExpression { get; set; }
        #endregion

        /* -------------------------------------------------------------------------------------
           informações a serem exibidas na view no site frontEnd (RSI)
        ------------------------------------------------------------------------------------- */
        #region frontEnd
        /// <summary>
        /// título a ser exibido na vitrine <h1>
        /// </summary>
        [DisplayName("título")]
        public string Title { get; set; }

        /// <summary>
        /// subtítulo a ser exibido na vitrine <h2>
        /// </summary>
        [DisplayName("sub-título")]
        public string SubTitle { get; set; }

        /// <summary>
        /// texto1 a ser exibido na vitrine <p> abaixo do sub-título da vitrine
        /// </summary>
        [DisplayName("texto do parágrafo1")]
        public string Paragraph1 { get; set; }

        /// <summary>
        /// texto2 a ser exibido na vitrine <p> abaixo do das imagens da vitrine (no rodapé da vitrine)
        /// </summary>
        [DisplayName("texto do parágrafo2")]
        public string Paragraph2 { get; set; }

        [DisplayName("cor de fundo")]
        public string BackgroundColor { get; set; }

        [DisplayName("cor do texto")]
        public string TextColor { get; set; }
        #endregion
        /* -------------------------------------------------------------------------------------
           campos de processamento automático, não editáveis
        ------------------------------------------------------------------------------------- */
        #region automaticFields
        /// <summary>
        /// campos que são atualizados apenas durante o processamento pelo sistema
        /// </summary>

        /// <summary>
        /// ordem de exibição das pageElments
        /// </summary>
        [DisplayName("ordem de exibição")]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// campo automático que realiza a contagem de registros que atendem aos critérios de seleção automática ou total de registros selecionados manualmente
        /// </summary>
        [DisplayName("número de registros vinculados")]
        public int TotalRegisters { get; set; }
        #endregion
        /* -------------------------------------------------------------------------------------
           lists, objects and other fields not mapped / temporários
        ------------------------------------------------------------------------------------- */
        #region lists
            //[NotMapped]
            //public List<AdvertisersShortList> AdvertisersShortList { get; set; }

            //[NotMapped]
            //public List<Ad_MediaList> Ad_MediaList { get; set; }

            [NotMapped]
            public Category CategoryObj { get; set; }

            [NotMapped]
            public SubCategory SubCategoryObj { get; set; }

            /// <summary>
            /// esse campo temporário irá conter a visão envolvida (ads (advertisings), adv (advertisers), wid (widgets),hom (home page), sid (sideBar), det (advertisers details), res (search result), hea (header), foo (footer))
            /// </summary>
            [NotMapped]
            public string view { get; set; }

            [NotMapped]
            public List<Tag> TagList { get; set; }

            //[NotMapped]
            //public List<Menu> MenuList { get; set; }
        #endregion

        /* -------------------------------------------------------------------------------------
          enums
       ------------------------------------------------------------------------------------- */
        //not Set = não configurado

        public enum selectiCriterion
        {
           a_definir, categoryId, subCategoryId, automaticByField, manualSelection
        }

        /// <summary>
        /// tipo de vitrine a ser usado para exibir os anunciantes
        /// </summary>
        public enum showCase_model
        {
            a_definir,
            grid, 
            grid_withFilter,
            gridCarousel,
            gridCarousel_withFilter,
            carousel,
            carousel_withFilter,
            carousel2,
            metro,
            list,
            list_withFilter,
            slider,
            grid_oneLine,
            brandsCarousel
        }

        /// <summary>
        /// tipo de anúncio:a_definir, image_single, slider, carousel, image_double, image_triple, image_quadruple, mediaEmbed (media incorporada, como os videos do youtube, soundcloud, etc)
        /// </summary>
        public enum advertising_model
        {
           a_definir, image_single, slider, carousel, image_double, image_triple, image_quadruple, mediaEmbed, metro
        }

        /// <summary>
        /// local de exibição da display (notSet, home, sideBar, header, footer, advertiserDetails, searchResult, otherPages)
        /// </summary>
        public enum display_local
        {
           a_definir, home, sideBar, header, footer, advertiserDetails, searchResult, otherPages
        }

        /// <summary>
        /// 0)notSet (não definido), 1)showCase (display do anunciante), 2)advertising (anúncio), 3)widget(menu de categorias por icons / imagens, search, tagsCloud, etc), section(aboutUs, contact, etc)
        /// </summary>   
        public enum display_type
        {
           a_definir, showCase, advertising, widget, section
        }

        /// <summary>
        /// tipo de mídia a ser utilizada
        /// </summary>
        public enum showCaseMedia_select
        {
           a_definir, logo, image, slider, carousel, youtube, vimeo, soundCloud, url
        }

        /// <summary>
        /// seleção do campo a ser usado como critério de seleção automática de registros 
        /// através das opções ategoryId, subCategoryId, tags, stripe, cityId, toDefine ou 
        /// definir que a seleção será "manual"
        /// </summary>
        public enum fieldToSselectRecords_criterion
        {
           a_definir, CategoryId, SubCategoryId, TagId, stripe, CityId, toDefine, manual
        }

        public enum widgetModel
        {
           a_definir, categoriesMenu, categoriesMenu_sideBar, TagsCloud_sidebar, google_AdWords_sidebar, google_AdWords, toDefineUrlPath, welcome, mainMenu, topMenu
        }

        public enum sectionModel
        {
           a_definir, contact, contact_sideBar, ourTeam, ourNumbers, whoWeAred, aboutUs, welcome, whyAdvertiseHere, youWantToAdvertiseHe, toDefineUrlPath
        }
    }    
}
