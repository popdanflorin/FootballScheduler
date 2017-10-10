namespace Football.Business
{
    public class Manager : Person
    {
        public int NoTeams { get; set; }
        public string Strategy { get; set; }
        public void ChangeStrategy(string newStrategy)
        {
            Strategy = newStrategy;
        }

        public bool DoTraining()
        {
            return true;
        }

        public void ChangePlayer(FieldPlayer playerOut, FieldPlayer playerIn)   //am pus totusi asta aici ca sa nu pot sa schimb sa zicem un jucator de la home
        {   //team cu unul de la guest. Asa o sa imi apelez de fiecare data managerul si asa ii mai clar ca nu se pot face confuzii
            playerOut.Out();
            playerIn.In();
        }
    }
}
