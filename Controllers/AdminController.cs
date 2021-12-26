using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Headers;
using System.IO;
using MuseumManagementSystem.Controllers;
using MuseumManagementSystem.Data;
using MuseumManagementSystem.Models;
using System.Text.RegularExpressions;

namespace MuseumManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MuseumManagementSystemDbContext _context;

        public AdminController(ILogger<HomeController> logger, MuseumManagementSystemDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
           return View();
        }

        public IActionResult MuzeEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MuzeEkle(Muze muze)
        {
            if (Request.Form.Files.Count > 0 && ModelState.IsValid)
            {
                string uzanti = Path.GetExtension(Request.Form.Files[0].FileName);
                var keyName = muze.MuzeAdi + muze.MuzeAdresi + muze.ZiyaretciSayisi.ToString() + uzanti;
                
                string route = "wwwroot/img/" + keyName; 
                using (FileStream fs = System.IO.File.Create(route))
                {
                    Request.Form.Files[0].CopyTo(fs);
                    fs.Flush();
                }
                muze.Foto = "/img/" + keyName;

                _context.Muze.Add(muze);
                _context.SaveChanges();
                ViewBag.Mesaj = "Ekleme İşlemi Başarılı";
                return View();
            }
            ViewBag.Mesaj = "Ekleme İşlemi Başarısız.";
            return View();
        }

        public IActionResult MuzeDuzenle()
        {
            var viewModel = _context.Muze.ToList();
            return View(viewModel);
        }

        public IActionResult MuzeUpdate(int id)
        {
            var viewModel = _context.Muze.Find(id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult MuzeUpdate(Muze muze, int id)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(100);
            var muz = _context.Muze.Find(id);
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    string uzanti = Path.GetExtension(Request.Form.Files[0].FileName);
                    var keyName = muze.MuzeAdi + muze.MuzeAdresi + muze.ZiyaretciSayisi.ToString() + sayi + uzanti;

                    using (FileStream fs = System.IO.File.Create(keyName))
                    {
                        Request.Form.Files[0].CopyTo(fs);
                        fs.Flush();
                    }
                    muz.Foto = "/img/" + keyName;
                    muz.MuzeAdi = muze.MuzeAdi;
                    muz.MuzeAdresi = muze.MuzeAdresi;
                    muz.ZiyaretciSayisi = muze.ZiyaretciSayisi;
                    _context.Muze.Update(muz);
                    _context.SaveChanges();
                    return RedirectToAction("MuzeDuzenle", "Admin");
                }
                else
                {
                    muz.MuzeAdi = muze.MuzeAdi;
                    muz.MuzeAdresi = muze.MuzeAdresi;
                    muz.ZiyaretciSayisi = muze.ZiyaretciSayisi;
                    _context.Muze.Update(muz);
                    _context.SaveChanges();
                    return RedirectToAction("MuzeDuzenle", "Admin");
                }
            }
            return RedirectToAction("MuzeDuzenle", "Admin");
        }

        public IActionResult MuzeSil(int id)
        {
            var muze = _context.Muze.Find(id);
            _context.Muze.Remove(muze);
            _context.SaveChanges();
            return RedirectToAction("MuzeDuzenle", "Admin");
        }

        public IActionResult EserEkle()
        {
            var viewModel = new EserMuzeler();
            viewModel.Muzeler = _context.Muze.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult EserEkle(Eser eser)
        {
            var viewModel = new EserMuzeler();
            viewModel.Muzeler = _context.Muze.ToList();
            if (Request.Form.Files.Count > 0 && ModelState.IsValid)
            {
                string uzanti = Path.GetExtension(Request.Form.Files[0].FileName);
                string dbAd = eser.EserAdi + eser.MuzeId.ToString() + eser.EserYili + uzanti;
                string yol = "wwwroot/img/" + dbAd;
                using (FileStream fs = System.IO.File.Create(yol))
                {
                    Request.Form.Files[0].CopyTo(fs);
                    fs.Flush();
                }
                eser.Foto = "/img/" + dbAd;
                eser.Muze = _context.Muze.Find(eser.MuzeId);
                _context.Eser.Add(eser);
                _context.SaveChanges();
                viewModel.Eser = eser;
                ViewBag.Mesaj = "Ekleme Başarılı";
                return View(viewModel);
            }
            ViewBag.Error = "Ekleme başarısız!";
            return View(viewModel);
        }

        public IActionResult EserDuzenle()
        {
            var viewModel = new EserlerMuzeler();
            viewModel.Eserler = _context.Eser.ToList();
            viewModel.Muzeler = _context.Muze.ToList();
            return View(viewModel);
        }
        public IActionResult EserSil(int id)
        {
            var eser = _context.Eser.Find(id);
            _context.Eser.Remove(eser);
            _context.SaveChanges();
            return RedirectToAction("EserDuzenle", "Admin");
        }

        public IActionResult EserUpdate(int id)
        {
            var eser = _context.Eser.Find(id);
            var viewModel = new EserMuzeler();
            viewModel.Muzeler = _context.Muze.ToList();
            viewModel.Eser = eser;

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult EserUpdate(Eser eser, int id)
        {
            Random rand = new Random();
            int sayi = rand.Next(100);
            var esr = _context.Eser.Find(id);
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    string uzanti = Path.GetExtension(Request.Form.Files[0].FileName);
                    string dbAd = eser.EserAdi + eser.MuzeId.ToString() + eser.EserYili + uzanti;
                    string yol = "wwwroot/img/" + dbAd;
                    using (FileStream fs = System.IO.File.Create(yol))
                    {
                        Request.Form.Files[0].CopyTo(fs);
                        fs.Flush();
                    }
                    esr.Foto = "/img/" + dbAd;
                    esr.EserAdi = eser.EserAdi;
                    esr.MuzeId = eser.MuzeId;
                    esr.EserYili = eser.EserYili;
                    esr.Muze = _context.Muze.Find(eser.MuzeId);
                    _context.Eser.Update(esr);
                    _context.SaveChanges();
                    return RedirectToAction("EserDuzenle", "Admin");
                }
                else
                {
                    esr.EserAdi = eser.EserAdi;
                    esr.MuzeId = eser.MuzeId;
                    esr.EserYili = eser.EserYili;
                    esr.Muze = _context.Muze.Find(eser.MuzeId);
                    _context.Eser.Update(esr);
                    _context.SaveChanges();
                    return RedirectToAction("EserDuzenle", "Admin");
                    _context.Eser.Update(esr);
                    _context.SaveChanges();
                    return RedirectToAction("EserDuzenle", "Admin");
                }
            }
            return RedirectToAction("EserDuzenle", "Admin");
        }
    }
}