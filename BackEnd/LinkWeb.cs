namespace IMAC.BackEnd
{
    class LinkWeb
    {

        public void CTA(string link, string Mlati, string Mlongi)
        {
            if (Mlati == "0" && Mlongi == "0")
            {
                (string lati, string longi) = GoogleLink.CallGoogleLink(link);
                string FullUrl = Base.BuildUrl(lati, longi);
            }

            else
            {
                string FullUrl = Base.BuildUrl(Mlati, Mlongi);
            }
        }
    }
}
