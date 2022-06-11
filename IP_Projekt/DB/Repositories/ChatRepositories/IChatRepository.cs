using IP_Projekt.DB.Models;

namespace IP_Projekt.DB.Repositories.ChatRepositories
{
    public interface IChatRepository
    {
        void StworzNowyChat(Chat chat);
        void WyslijWiadomosc(Msg msg);
        List<Msg> PobierzWiadomosciCzatu(int idChatu);
        Chat PobierzAktywnyChatMiedzyUzytkownikami(int idPacjenta, int idLekarza);
        void ZakonczChat(int idChatu);
    }
}
