using rsi.Apps;
using rsi.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rsi.ViewModels;

namespace rsi.Ui.Areas.backEnd.Controllers
{
    public class DashboardController : Controller
    {
        Context _context = new Context();
        
        public PartialViewResult AreaChartJs()
        {
            // pegar o número da semana atual:
            int _this_Week = __weekNumber(System.DateTime.Now);
            List<Statistic> _statisticList = _context.Statistics.ToList();
            List<Statistic> _statistic_thisWeekList = new List<Statistic>();
            List<Statistic> _statistic_lastWeekList = new List<Statistic>();
            int _thisWeekTotal_monday = 0;
            int _thisWeekTotal_tuesday = 0;
            int _thisWeekTotal_wednesday = 0;
            int _thisWeekTotal_thursday = 0;
            int _thisWeekTotal_friday = 0;
            int _thisWeekTotal_saturday = 0;
            int _thisWeekTotal_sunday = 0;

            int _lastWeekTotal_monday = 0;
            int _lastWeekTotal_tuesday = 0;
            int _lastWeekTotal_wednesday = 0;
            int _lastWeekTotal_thursday = 0;
            int _lastWeekTotal_friday = 0;
            int _lastWeekTotal_saturday = 0;
            int _lastWeekTotal_sunday = 0;

            var _firstDayOfTheWeek = System.DateTime.Now;
            var _lastDayOfTheWeek = System.DateTime.Now;

            // separar os registros da semana atual:
            foreach (var _item in _statisticList)
            {
                if (__weekNumber(_item.StartOfVisit) == _this_Week)
                {
                    _statistic_thisWeekList.Add(_item);

                    // totalizar por dia da semana:                    
                    _thisWeekTotal_monday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "monday" ? 1 : 0;
                    _thisWeekTotal_tuesday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "tuesday" ? 1 : 0;
                    _thisWeekTotal_wednesday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "wednesday" ? 1 : 0;
                    _thisWeekTotal_thursday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "thursday" ? 1 : 0;
                    _thisWeekTotal_friday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "friday" ? 1 : 0;
                    _thisWeekTotal_saturday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "saturday" ? 1 : 0;
                    _thisWeekTotal_sunday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "sunday" ? 1 : 0;

                    if (_item.StartOfVisit.DayOfWeek.ToString().ToLower() == "sunday")
                        _firstDayOfTheWeek = _item.StartOfVisit;

                    if (_item.StartOfVisit.DayOfWeek.ToString().ToLower() == "saturday")
                        _lastDayOfTheWeek = _item.StartOfVisit;
                }
            }
            ViewBag.ThisWeekTotal = _statistic_thisWeekList.Count;
            ViewBag.ThisWeekTotal_monday = _thisWeekTotal_monday;
            ViewBag.ThisWeekTotal_tuesday = _thisWeekTotal_tuesday;
            ViewBag.ThisWeekTotal_wednesday = _thisWeekTotal_wednesday;
            ViewBag.ThisWeekTotal_thursday = _thisWeekTotal_thursday;
            ViewBag.ThisWeekTotal_friday = _thisWeekTotal_friday;
            ViewBag.ThisWeekTotal_saturday = _thisWeekTotal_saturday;
            ViewBag.ThisWeekTotal_sunday = _thisWeekTotal_sunday;

            // separar os registros da semana anterior:
            foreach (var _item in _statisticList)
            {
                if (__weekNumber(_item.StartOfVisit) == (_this_Week - 1))
                    _statistic_lastWeekList.Add(_item);

                // totalizar por dia da semana:                    
                _lastWeekTotal_monday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "monday" ? 1 : 0;
                _lastWeekTotal_tuesday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "tuesday" ? 1 : 0;
                _lastWeekTotal_wednesday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "wednesday" ? 1 : 0;
                _lastWeekTotal_thursday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "thursday" ? 1 : 0;
                _lastWeekTotal_friday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "friday" ? 1 : 0;
                _lastWeekTotal_saturday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "saturday" ? 1 : 0;
                _lastWeekTotal_sunday += _item.StartOfVisit.DayOfWeek.ToString().ToLower() == "sunday" ? 1 : 0;
            }

            ViewBag.LastWeekTotal = _statistic_thisWeekList.Count;
            ViewBag.LastWeekTotal_monday = _lastWeekTotal_monday;
            ViewBag.LastWeekTotal_tuesday = _lastWeekTotal_tuesday;
            ViewBag.LastWeekTotal_wednesday = _lastWeekTotal_wednesday;
            ViewBag.LastWeekTotal_thursday = _lastWeekTotal_thursday;
            ViewBag.LastWeekTotal_friday = _lastWeekTotal_friday;
            ViewBag.LastWeekTotal_saturday = _lastWeekTotal_saturday;
            ViewBag.LastWeekTotal_sunday = _lastWeekTotal_sunday;

            ViewBag.Statistic_thisWeekList = _statistic_thisWeekList;
            ViewBag.Statistic_lastWeekList = _statistic_lastWeekList;

            ViewBag.This_Week = _this_Week;

            ViewBag.ChartTitle = "semana #" + _this_Week.ToString() + " - num" + (char)186 + " views (de " + _firstDayOfTheWeek.Day.ToString() + "/" + _firstDayOfTheWeek.ToString("MMM") + " à " + _lastDayOfTheWeek.Day.ToString() + "/" + _lastDayOfTheWeek.ToString("MMM") + ")";

            return PartialView(_statistic_thisWeekList);
        }

        /// <summary>
        /// função que retorna o número da semana relativa ao ano
        /// </summary>
        /// <param name="__dt">a data que se deseja saber o número da semana</param>
        /// <returns></returns>
        public int __weekNumber(DateTime __dt)
        {
            System.Globalization.CultureInfo calendarioLocal = new CultureInfo("PT-BR");
            return calendarioLocal.Calendar.GetWeekOfYear(__dt, System.Globalization.CalendarWeekRule.FirstFourDayWeek, System.DayOfWeek.Sunday);
        }

        public PartialViewResult LineChartJs()
        {
            // ler tabela de anunciantes
            ViewBag.TotalAdvertisers_jan = _context.Advertisers.Where(x => x.AddDate.Month == 1).Count();
            ViewBag.TotalAdvertisers_fev = _context.Advertisers.Where(x => x.AddDate.Month == 2).Count();
            ViewBag.TotalAdvertisers_mar = _context.Advertisers.Where(x => x.AddDate.Month == 3).Count();
            ViewBag.TotalAdvertisers_abr = _context.Advertisers.Where(x => x.AddDate.Month == 4).Count();
            ViewBag.TotalAdvertisers_mai = _context.Advertisers.Where(x => x.AddDate.Month == 5).Count();
            ViewBag.TotalAdvertisers_jun = _context.Advertisers.Where(x => x.AddDate.Month == 6).Count();
            ViewBag.TotalAdvertisers_jul = _context.Advertisers.Where(x => x.AddDate.Month == 7).Count();
            ViewBag.TotalAdvertisers_ago = _context.Advertisers.Where(x => x.AddDate.Month == 8).Count();
            ViewBag.TotalAdvertisers_set = _context.Advertisers.Where(x => x.AddDate.Month == 9).Count();
            ViewBag.TotalAdvertisers_out = _context.Advertisers.Where(x => x.AddDate.Month == 10).Count();
            ViewBag.TotalAdvertisers_nov = _context.Advertisers.Where(x => x.AddDate.Month == 11).Count();
            ViewBag.TotalAdvertisers_dez = _context.Advertisers.Where(x => x.AddDate.Month == 12).Count();
            // totalizar por mês o número de anunciantes adicionados

            ViewBag.ChartLineTitle = "número de anunciantes/mês (real x meta)";

            return PartialView();
        }

        public PartialViewResult BarChartJs()
        {
            var _vds_mounthRefer = TotalSalesPerAdvertiser(System.DateTime.Now.Month);
            ViewBag.Vds_mounthLast = TotalSalesPerAdvertiser((System.DateTime.Now.Month - 1));

            return PartialView(_vds_mounthRefer);
        }

        public PartialViewResult DonutChartJs()
        {
            return PartialView();
        }

        public PartialViewResult PieChartJs()
        {
            //// 1) preencher lista com os anunciantes ativos com o total de views de cada um
            //var _advertisersList = _context.Advertisers.Where(x => x.St == status.on).ToList();
            //List<PieChart> _pieChartList = new List<PieChart>();
            //foreach(var _item in _advertisersList)
            //{
            //    PieChart _pieChartObj = new PieChart()
            //    {
            //        AdvertiserId = _item.Id,
            //        AdvertiserName = _item.Name,
            //        TotalViews = _context.Statistics.Where(x => x.AdvertiserId == _item.Id).Count()
            //    };
            //    _pieChartList.Add(_pieChartObj);
            //}

            //// 3) montar o ranking dos 5 primeiros e acumular o restante
            //PieChart_slices _pieChart_slicesObj = new PieChart_slices();
            //int _indice = 1;
            //foreach (var _item in _pieChartList.OrderByDescending(x=>x.TotalViews))
            //{
            //    if (_indice == 1)
            //    {
            //        _pieChart_slicesObj.TotalViews_slice1 = _item.TotalViews;
            //        _pieChart_slicesObj.AdvertiserName_slice1 = _item.AdvertiserName;
            //    }
            //    else if (_indice == 2)
            //    {
            //        _pieChart_slicesObj.TotalViews_slice2 = _item.TotalViews;
            //        _pieChart_slicesObj.AdvertiserName_slice2 = _item.AdvertiserName;
            //    }
            //    else if (_indice == 3)
            //    {
            //        _pieChart_slicesObj.TotalViews_slice3 = _item.TotalViews;
            //        _pieChart_slicesObj.AdvertiserName_slice3 = _item.AdvertiserName;
            //    }
            //    else if (_indice == 4)
            //    {
            //        _pieChart_slicesObj.TotalViews_slice4 = _item.TotalViews;
            //        _pieChart_slicesObj.AdvertiserName_slice4 = _item.AdvertiserName;
            //    }
            //    else if (_indice == 5)
            //    {
            //        _pieChart_slicesObj.TotalViews_slice5 = _item.TotalViews;
            //        _pieChart_slicesObj.AdvertiserName_slice5 = _item.AdvertiserName;
            //    }
            //    else if (_indice > 5)
            //    {
            //        _pieChart_slicesObj.TotalViews_remainingSlices += _item.TotalViews;
            //    }
            //    _indice++;
            //}

            return PartialView(TotalSalesPerAdvertiser(System.DateTime.Now.Month));
        }

        public PieChart_slices TotalSalesPerAdvertiser(int __mounthRefer)
        {
            __mounthRefer = __mounthRefer < 1 ? System.DateTime.Now.Month : __mounthRefer;
            // 1) preencher lista com os anunciantes ativos com o total de views de cada um
            var _advertisersList = _context.Advertisers.Where(x => x.St == status.on).ToList();
            List<PieChart> _pieChartList = new List<PieChart>();
            foreach (var _item in _advertisersList)
            {
                PieChart _pieChartObj = new PieChart()
                {
                    AdvertiserId = _item.Id,
                    AdvertiserName = rsi.Apps.Functions.__maximumSizeOfTheText(_item.Name, 15),
                    TotalViews = _context.Statistics.Where(x => x.AdvertiserId == _item.Id && x.StartOfVisit.Month == __mounthRefer).Count()
                };
                _pieChartList.Add(_pieChartObj);
            }

            // 3) montar o ranking dos 5 primeiros e acumular o restante
            PieChart_slices _pieChart_slicesObj = new PieChart_slices();
            int _indice = 1;
            foreach (var _item in _pieChartList.OrderByDescending(x => x.TotalViews))
            {
                if (_indice == 1)
                {
                    _pieChart_slicesObj.TotalViews_slice1 = _item.TotalViews;
                    _pieChart_slicesObj.AdvertiserName_slice1 = _item.AdvertiserName;
                    _pieChart_slicesObj.AdvertiserShortName_slice1 = rsi.Apps.Functions.__maximumSizeOfTheText(_item.AdvertiserName, 15);
                    _pieChart_slicesObj.AdvertiserId_slice1 = _item.AdvertiserId;
                }
                else if (_indice == 2)
                {
                    _pieChart_slicesObj.TotalViews_slice2 = _item.TotalViews;
                    _pieChart_slicesObj.AdvertiserName_slice2 = _item.AdvertiserName;
                    _pieChart_slicesObj.AdvertiserShortName_slice2 = rsi.Apps.Functions.__maximumSizeOfTheText(_item.AdvertiserName, 15);
                    _pieChart_slicesObj.AdvertiserId_slice2 = _item.AdvertiserId;
                }
                else if (_indice == 3)
                {
                    _pieChart_slicesObj.TotalViews_slice3 = _item.TotalViews;
                    _pieChart_slicesObj.AdvertiserName_slice3 = _item.AdvertiserName;
                    _pieChart_slicesObj.AdvertiserShortName_slice3 = rsi.Apps.Functions.__maximumSizeOfTheText(_item.AdvertiserName, 15);
                    _pieChart_slicesObj.AdvertiserId_slice3 = _item.AdvertiserId;
                }
                else if (_indice == 4)
                {
                    _pieChart_slicesObj.TotalViews_slice4 = _item.TotalViews;
                    _pieChart_slicesObj.AdvertiserName_slice4 = _item.AdvertiserName;
                    _pieChart_slicesObj.AdvertiserShortName_slice4 = rsi.Apps.Functions.__maximumSizeOfTheText(_item.AdvertiserName, 15);
                    _pieChart_slicesObj.AdvertiserId_slice4 = _item.AdvertiserId;
                }
                else if (_indice == 5)
                {
                    _pieChart_slicesObj.TotalViews_slice5 = _item.TotalViews;
                    _pieChart_slicesObj.AdvertiserName_slice5 = _item.AdvertiserName;
                    _pieChart_slicesObj.AdvertiserShortName_slice5 = rsi.Apps.Functions.__maximumSizeOfTheText(_item.AdvertiserName, 15);
                    _pieChart_slicesObj.AdvertiserId_slice5 = _item.AdvertiserId;
                }
                else if (_indice > 5)
                {
                    _pieChart_slicesObj.TotalViews_remainingSlices += _item.TotalViews;
                }
                _indice++;
            }

            return _pieChart_slicesObj;
        }

        public ActionResult ReportDetails(int id)
        {
            return View(StatisticListReturn(id));
        }

        public List<Statistic> StatisticListReturn(int __week)
        {
            List<Statistic> _statisticList = _context.Statistics.ToList();
            List<Statistic> _statisticListTemp = new List<Statistic>();

            foreach (var _item in _statisticList)
            {
                Statistic _statisticObjTemp = new Statistic();

                if (__weekNumber(_item.StartOfVisit) == __week)
                {
                    _statisticObjTemp = _item;
                    _statisticObjTemp.AdvertiserName = _context.Advertisers.FirstOrDefault(x => x.Id == _item.AdvertiserId).Name;
                    _statisticListTemp.Add(_statisticObjTemp);
                }
            }

            return _statisticListTemp;
        }

        //public List<Statistic> StatisticListReturn2()
        //{
        //    // contar o número de anunciantes ativos
        //    int _advertisers_total = _context.Advertisers.Where(x => x.St == status.on).Count();

        //    // criar um array que irá armazenar os totais de cada anunciante
        //    int[] views_per_advertiser = new int[_advertisers_total];

        //    // criar array com os nomes dos anunciantes
        //    string[] _advertisersName = new string[_advertisers_total];

        //    // criar array com os id dos anunciantes
        //    int[] _advertisersId = new int[_advertisers_total];

        //    int _x = 1;
        //    foreach (var _item in _context.Advertisers.Where(x=>x.St == status.on))
        //    {
        //        _advertisersName[_x] = _item.Name;
        //        _advertisersId[_x] = _item.Id;
        //        _x++;
        //    }

        //    //listar a tabela de estatíticas
        //    List<Statistic> _statisticList = _context.Statistics.ToList();

        //    for (int x=1;x <= _advertisers_total; x++)
        //    {
        //        views_per_advertiser[x] = _context.Statistics.Where(i => i.AdvertiserId == _advertisersId[x]).Count();
        //    }
        //    List<Statistic> _statisticListTemp = new List<Statistic>();

        //    foreach (var _item in _statisticList)
        //    {
        //        Statistic _statisticObjTemp = new Statistic();

        //        _statisticObjTemp = _item;
        //        _statisticObjTemp.AdvertiserName = _context.Advertisers.FirstOrDefault(x => x.Id == _item.AdvertiserId).Name;
        //        _statisticListTemp.Add(_statisticObjTemp);

        //    }

        //    return _statisticListTemp;
        //}

        public PartialViewResult Watchers_onLineviews()
        {
            return PartialView();
        }

        public PartialViewResult Watchers_advertisersTotal()
        {

            return PartialView(_context.Advertisers.Where(x => x.St == status.on).Count());
        }

        public PartialViewResult Watchers_messagesToAdvertisersTotal()
        {
            var _messagesFullList = _context.EmailBoxes.ToList();
            var _messagesList = _messagesFullList.Where(x => x.ReadingStatus == readingStatus.read || x.ReadingStatus == readingStatus.Unread).ToList();
            var _messagesToAdvertiserList = _messagesList.Where(x => x.Receiver == receiver.toAdvertiser);
            ViewBag.MessagesToAdvertiserListCountNotRead = _messagesToAdvertiserList.Where(x => x.ReadingStatus == readingStatus.Unread).Count();

            return PartialView(_context.EmailBoxes.Where(x => x.Receiver == receiver.toAdvertiser && (x.ReadingStatus == readingStatus.read || x.ReadingStatus == readingStatus.Unread)).Count());
        }

        public PartialViewResult Watchers_messagesToSiteTotal()
        {
            var _messagesFullList = _context.EmailBoxes.ToList();
            var _messagesList = _messagesFullList.Where(x => x.ReadingStatus == readingStatus.read || x.ReadingStatus == readingStatus.Unread).ToList();
            var _messagesToSiteOwnerList = _messagesList.Where(x => x.Receiver == receiver.toSiteOwner);

            ViewBag.MessagesToSiteOwnerListCountNotRead = _messagesToSiteOwnerList.Where(x => x.ReadingStatus == readingStatus.Unread).Count();

            return PartialView(_context.EmailBoxes.Where(x => x.Receiver == receiver.toSiteOwner && (x.ReadingStatus == readingStatus.read || x.ReadingStatus == readingStatus.Unread)).Count());
        }

        public PartialViewResult RecentlyAddedAdvertisings()
        {
            return PartialView(_context.Displays.Where(x => x.Display_type == Display.display_type.advertising).OrderByDescending(x => x.AddDate).Take(4).ToList());
        }

        //public PartialViewResult LatestAdvertisers()
        //{
        //    return PartialView(_advertisersApp.ListAll("full").Where(x => x.St == status.on).OrderByDescending(x => x.AddDate).Take(8).ToList());
        //}
    }
}