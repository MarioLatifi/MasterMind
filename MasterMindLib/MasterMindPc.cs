namespace MasterMindLib
{
    public class MasterMindPc : IGenerator
    {
        public Colors[] Code { get; private set; }
        public MasterMindPc(int difficulty)                           
        {
            Code = new Colors[4];
            Difficulty = difficulty;
        }
        private int Difficulty { get; set; }
        
        public Colors[] GenerateSecretCode()
        {
            Random rnd = new Random();
            List<Colors> availableColors = Enum.GetValues(typeof(Colors))
                .Cast<Colors>()
                .Where(color => (int)color <= Difficulty && color != Colors.WHITE)
                .ToList();
            for (int i = 0; i < Code.Length; i++)
            {
                int index = rnd.Next(availableColors.Count);
                Code[i] = availableColors[index];
                if (Difficulty>3||Difficulty==1||Difficulty==0)
                {
                    availableColors.RemoveAt(index);
                }
            }
            return Code;
        }
    }
}
