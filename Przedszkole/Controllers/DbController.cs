using Microsoft.AspNetCore.Mvc;
using PrzedszkoleData.Data;
using PrzedszkoleData.Data.CMS;

namespace Przedszkole.Controllers
{
    public class DbController : Controller
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ILogger<HomeController> _logger;

        public DbController(ILogger<HomeController> logger, ApplicationDbContext _context)
        {
            _logger = logger;
            this._context = _context;
        }

        public void WywolajViewBagi()
        {
            ViewBag.ModelOpis =
                (
                    from Opis in _context.Opis
                    where Opis.CzyAktywny == true
                    select Opis
                ).ToList();

            ViewBag.ModelStopka =
                (
                    from Stopka in _context.Stopka
                    where Stopka.CzyAktywny == true
                    select Stopka
                ).ToList();

            ViewBag.ModelInformacje =
                (
                    from Informacje in _context.Informacje
                    where Informacje.CzyAktywny == true
                    select Informacje
                ).ToList();

            ViewBag.ModelNazwa =
                (
                    from Nazwa in _context.Nazwa
                    where Nazwa.CzyAktywny == true
                    select Nazwa
                ).ToList();

            ViewBag.ModelCennik =
                (
                    from Cennik in _context.Cennik
                    where Cennik.CzyAktywny == true
                    select Cennik
                ).ToList();

        }

        public void WywolajViewBagiONas()
        {
            ViewBag.ModelOpis =
                (
                    from Opis in _context.Opis
                    where Opis.CzyAktywny == true
                    select Opis
                ).ToList();

            ViewBag.ModelStopka =
                (
                    from Stopka in _context.Stopka
                    where Stopka.CzyAktywny == true
                    select Stopka
                ).ToList();

            ViewBag.ModelNazwa =
                (
                    from Nazwa in _context.Nazwa
                    where Nazwa.CzyAktywny == true
                    select Nazwa
                ).ToList();

            ViewBag.ModelONas =
               (
                   from ONas in _context.ONas
                   where ONas.CzyAktywny == true
                   select ONas
               ).ToList();

            ViewBag.ModelHarmnogramDzienny =
                (
                    from HarmonogramDzienny in _context.HarmonogramDzienny
                    where HarmonogramDzienny.CzyAktywny == true
                    select HarmonogramDzienny
                ).ToList();

            ViewBag.ModelMenu =
            (
                from Menu in _context.Menu
                where Menu.CzyAktywny == true && Menu.Dzien == DateTime.Today.Date
                select Menu
            ).ToList();


        }

        public void WywolajViewBagiZajecia()
        {
            ViewBag.ModelOpis =
            (
                from Opis in _context.Opis
                where Opis.CzyAktywny == true
                select Opis
            ).ToList();

            ViewBag.ModelStopka =
                (
                    from Stopka in _context.Stopka
                    where Stopka.CzyAktywny == true
                    select Stopka
                ).ToList();

            ViewBag.ModelNazwa =
                (
                    from Nazwa in _context.Nazwa
                    where Nazwa.CzyAktywny == true
                    select Nazwa
                ).ToList();

            ViewBag.ModelZajeciaDodatkowe =
                (
                    from ZajeciaDodatkowe in _context.ZajeciaDodatkowe
                    where ZajeciaDodatkowe.CzyAktywny == true
                    select ZajeciaDodatkowe
                ).ToList();
            ViewBag.ModelZajeciaPodstawowe =
                (
                    from ZajeciaPodstawowe in _context.ZajeciaPodstawowe
                    where ZajeciaPodstawowe.CzyAktywny == true
                    select ZajeciaPodstawowe
                ).ToList();


        }

        public void WywolajViewBagiCennik()
        {
            ViewBag.ModelOpis =
                (
                    from Opis in _context.Opis
                    where Opis.CzyAktywny == true
                    select Opis
                ).ToList();

            ViewBag.ModelStopka =
                (
                    from Stopka in _context.Stopka
                    where Stopka.CzyAktywny == true
                    select Stopka
                ).ToList();

            ViewBag.ModelNazwa =
                (
                    from Nazwa in _context.Nazwa
                    where Nazwa.CzyAktywny == true
                    select Nazwa
                ).ToList();

            ViewBag.ModelCennik =
                (
                    from Cennik in _context.Cennik
                    where Cennik.CzyAktywny == true
                    select Cennik
                ).ToList();



        }

        public void WywolajViewBagiKontakt()
        {
            ViewBag.ModelOpis =
                (
                    from Opis in _context.Opis
                    where Opis.CzyAktywny == true
                    select Opis
                ).ToList();

            ViewBag.ModelStopka =
                (
                    from Stopka in _context.Stopka
                    where Stopka.CzyAktywny == true
                    select Stopka
                ).ToList();

            ViewBag.ModelNazwa =
                (
                    from Nazwa in _context.Nazwa
                    where Nazwa.CzyAktywny == true
                    select Nazwa
                ).ToList();

            ViewBag.ModelKontakt =
                (
                    from Kontakt in _context.Kontakt
                    where Kontakt.CzyAktywny == true
                    select Kontakt
                ).ToList();
            ViewBag.ModelAdres =
                (
                    from Adres in _context.Adres
                    where Adres.CzyAktywny == true
                    select Adres
                ).ToList();



        }

        public void WywolajViewBagiPersonel()
        {
            ViewBag.ModelOpis =
                (
                    from Opis in _context.Opis
                    where Opis.CzyAktywny == true
                    select Opis
                ).ToList();

            ViewBag.ModelStopka =
                (
                    from Stopka in _context.Stopka
                    where Stopka.CzyAktywny == true
                    select Stopka
                ).ToList();

            ViewBag.ModelNazwa =
                (
                    from Nazwa in _context.Nazwa
                    where Nazwa.CzyAktywny == true
                    select Nazwa
                ).ToList();

            ViewBag.ModelPersonel =
                (
                    from Personel in _context.Personel
                    select Personel
                ).ToList();



        }
    }
}

