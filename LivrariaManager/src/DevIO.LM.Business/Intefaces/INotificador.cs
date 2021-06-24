using DevIO.LM.Business.Notificacoes;
using System.Collections.Generic;

namespace DevIO.LM.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
