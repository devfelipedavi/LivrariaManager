using AutoMapper;
using DevIO.LM.App.ViewModels;
using DevIO.LM.Business.Models;

namespace DevIO.LM.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Aluguel, AluguelViewModel>().ReverseMap();
            CreateMap<Editora, EditoraViewModel>().ReverseMap();            
            CreateMap<Livro, LivroViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
        }
    }
}
