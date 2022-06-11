using IP_Projekt.DB.Models;

namespace IP_Projekt.DB.Repositories.ChatRepositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly IpprojContext _ipprojContext;
        public ChatRepository(IpprojContext ipprojContext)
        {
            _ipprojContext = ipprojContext;
        }

        public Chat PobierzAktywnyChatMiedzyUzytkownikami(int idPacjenta, int idLekarza)
        {
            Chat aktywnyChat = _ipprojContext.Chats.Where(
                x => x.Patient_ID == idPacjenta 
                && x.Doctor_ID == idLekarza 
                && x.IsActive == true)
                .FirstOrDefault();

            return aktywnyChat;
        }

        public List<Msg> PobierzWiadomosciCzatu(int idChatu)
        {
            IQueryable<Msg> wiadomosci = _ipprojContext.Msgs.Where(x => x.chat_ID == idChatu);

            return wiadomosci.ToList();
        }

        public void StworzNowyChat(Chat chat)
        {
            _ipprojContext.Chats.Add(chat);
            _ipprojContext.SaveChanges();
        }

        public void WyslijWiadomosc(Msg msg)
        {
            _ipprojContext.Msgs.Add(msg);
            _ipprojContext.SaveChanges();
        }

        public void ZakonczChat(int idChatu)
        {
            Chat doZakonczenia = _ipprojContext.Chats.SingleOrDefault(x => x.Id == idChatu);
            if (doZakonczenia != null && doZakonczenia.IsActive != true)
            {
                doZakonczenia.IsActive = true;
                _ipprojContext.SaveChanges();
            }
        }
    }
}
