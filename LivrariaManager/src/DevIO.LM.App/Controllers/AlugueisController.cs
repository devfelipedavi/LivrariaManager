using AutoMapper;
using DevIO.LM.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.LM.App.Controllers
{
    public class AlugueisController : BaseController
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly IAluguelService _aluguelService;
        private readonly IMapper _mapper;

        public AlugueisController(IAluguelRepository aluguelRepository,
                                      IMapper mapper,
                                      IAluguelService aluguelService,
                                      INotificador notificador) : base(notificador)
        {
            _aluguelRepository = aluguelRepository;
            _mapper = mapper;
            _aluguelService = aluguelService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
