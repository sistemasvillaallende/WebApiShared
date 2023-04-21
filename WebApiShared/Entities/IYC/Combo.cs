namespace WebApiShared.Entities
{
    public class Combo
    {
        public string value { get; set; }
        public string text { get; set; }
        public string cod_enlaza { get; set; }

        public Combo()
        { 
            value = string.Empty;
            text = string.Empty;
            cod_enlaza = string.Empty;
        }
    }
}
