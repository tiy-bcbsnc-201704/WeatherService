

namespace Weather.LocationTranslator
{
   public  class LongLatCalcs
    {

        public string StateForLongLat(double longitude, double latitude)
        {

            string longLatState = "";
            double plusOrminus = 0;
            double maxplusOrminus = 5.0;


            // determine longLatState
            /*
            while (true)
                {
                longLatState = select count(*)
                    if (any found)
                    {
                    return longLatState;
                }
                    else if (plusOrminus == maxplusOrminus)
                {
                    return "XX";
                }
                else
                {
                    plusORminus += .10;

                }
            }
            */

            longLatState = "AK";
            return longLatState;

        }


    }
}
