namespace IMAC.BackEnd
{
    class GoogleLink
    {
        public static (string, string) CallGoogleLink(string googleUrl)
        {
            int latiStartIndex = googleUrl.IndexOf("@") + 1; // Índice de início da latitude
            int commaIndex = googleUrl.IndexOf(",", latiStartIndex); // Índice da vírgula após a latitude
            string latiGoogle = googleUrl.Substring(latiStartIndex, commaIndex - latiStartIndex); // Extrai a latitude
            int longiStartIndex = commaIndex + 1; // Índice do início da longitude
            int commaIndex2 = googleUrl.IndexOf(",", longiStartIndex); // **Índice do início da string que contém o nível de zoom**
            string longiGoogle = googleUrl.Substring(longiStartIndex, commaIndex2 - longiStartIndex - 1); // Extrai a longitude

            _ = latiGoogle.Replace("@", ""); // Remove o caractere "@" do início da string da latitude
            _ = longiGoogle.Replace(",", ""); // Remove a vírgula no final da longitude

            return (latiGoogle, longiGoogle);
        }
    }
}
