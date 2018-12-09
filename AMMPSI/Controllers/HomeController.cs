using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AMMPSI.Models;
using AMMPSI.Data;
using Microsoft.AspNetCore.Authorization;

namespace AMMPSI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly AMContext _context;

        public HomeController(AMContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetThisYearApprovalRequest()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<int> dataList = new List<int>();

            await Task.Run(() =>
            {
                for (int i = 1; i < 13; i++)
                {
                    dataList.Add(_context.Movement.Where(x => x.MovementDate.Year == DateTime.Now.Year && x.MovementDate.Month == i && x.Status.ToUpper() == "ORDER").Count());
                }
            });

            return Ok(dataList.ToArray());
        }

        [HttpPost]
        public async Task<IActionResult> GetThisYearTask()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<int> dataList = new List<int>();

            await Task.Run(() =>
            {
                for (int i = 1; i < 13; i++)
                {
                    dataList.Add(_context.Movement.Where(x => x.MovementDate.Year == DateTime.Now.Year && x.MovementDate.Month == i && x.Status.ToUpper() == "APPROVE").Count());
                }
            });

            return Ok(dataList.ToArray());
        }

        [HttpPost]
        public async Task<IActionResult> GetThisYearAsset()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<int> dataList = new List<int>();

            await Task.Run(() =>
            {
                for (int i = 1; i < 13; i++)
                {
                    dataList.Add(_context.Asset.Where(x => x.CreatedDate.Year == DateTime.Now.Year && x.CreatedDate.Month == i).Count());
                }
            });

            return Ok(dataList.ToArray());
        }

        [HttpPost]
        public async Task<IActionResult> GetThisYearApprovalAndTaskCount()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<int> dataList = new List<int>();

            await Task.Run(() =>
            {
                dataList.Add(_context.Movement.Where(x => x.MovementDate.Year == DateTime.Now.Year && x.MovementDate.Year == DateTime.Now.Year && x.Status.ToUpper() == "ORDER").Count());
                dataList.Add(_context.Movement.Where(x => x.MovementDate.Year == DateTime.Now.Year && x.MovementDate.Year == DateTime.Now.Year && x.Status.ToUpper() == "APPROVE").Count());
            });

            return Ok(dataList.ToArray());
        }

        [HttpPost]
        public async Task<IActionResult> GetLastActivities()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<LastActivitiesViewModel> dataList = new List<LastActivitiesViewModel>();

            await Task.Run(() =>
            {
                var data = _context.Movement.TakeLast(5);

                foreach (var item in data)
                {
                    foreach (var i in item.MovementItem)
                    {
                        dataList.Add(
                            new LastActivitiesViewModel
                            {
                                UserName = item.CreatedBy,
                                AssetName = i.Asset.Name,
                                Status = item.Status,
                                CurrentLocation = item.Location.Name,
                                ActivityTime = ActivityTimeFunc(item.CreatedDate)
                            }
                        );
                    }

                }

                //dataList.Add(
                //            new LastActivitiesViewModel
                //            {
                //                UserName = "Ryan Gunawan",
                //                AssetName = "Meja",
                //                Status = "ORDER",
                //                CurrentLocation = "Dapur",
                //                ActivityTime = "5 hours ago"
                //            }
                //        );
                //dataList.Add(
                //            new LastActivitiesViewModel
                //            {
                //                UserName = "Ryan Gunawan",
                //                AssetName = "Meja",
                //                Status = "ORDER",
                //                CurrentLocation = "Dapur",
                //                ActivityTime = "5 hours ago"
                //            }
                //        );
                //dataList.Add(
                //            new LastActivitiesViewModel
                //            {
                //                UserName = "Ryan Gunawan",
                //                AssetName = "Meja",
                //                Status = "ORDER",
                //                CurrentLocation = "Dapur",
                //                ActivityTime = "5 hours ago"
                //            }
                //        );
            });

            return Ok(dataList.ToArray());
        }

        private string ActivityTimeFunc(DateTime date)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - date.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
