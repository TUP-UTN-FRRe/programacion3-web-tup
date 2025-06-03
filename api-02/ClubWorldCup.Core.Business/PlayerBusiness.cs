using ClubWorldCup.Core.Entities;

namespace ClubWorldCup.Core.Business
{
    public class PlayerBusiness
    {
        private List<Player> _players = new List<Player>
            {
                new Player { Id = 1, Name = "Lionel Messi", Position = "Forward", Number = 10 },
                new Player { Id = 2, Name = "Cristiano Ronaldo", Position = "Forward", Number = 7 },
                new Player { Id = 3, Name = "Neymar Jr.", Position = "Forward", Number = 11 },
                new Player { Id = 4, Name = "Kevin De Bruyne", Position = "Midfielder", Number = 17 },
                new Player { Id = 5, Name = "Virgil van Dijk", Position = "Defender", Number = 4 }
            };


        public PlayerBusiness() { 
        
        }

        public Player FindByNumber(int number)
        {
            var query = from p in GetAll()
                        where p.Number == number
                        select p;

            //var query2 = GetAll().Where(p => p.Number == number)
            //                     .Select(p => p);

            return query.FirstOrDefault();
        }


        public List<Player> GetAll()
        {
            return _players;
        }

        public void Add(Player player) {

            _players.Add(player);
        }

    }
}
