using System;
using System.Text;
namespace PhoneApp
{
    public class PhoneTranslator
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string Numbers = "22233344455566677778889999";


       

        public string ToNumber(string alfanumber)
        {
            var numericphonenumber=new StringBuilder();
            if (!string.IsNullOrEmpty(alfanumber)) 
            {
                alfanumber = alfanumber.ToUpper();
                foreach (var c in alfanumber)
                {
                    if ("0123456789".IndexOf(c) >= 0){

                        numericphonenumber.Append(c);

                    }   
                    else{
                        var index = letters.IndexOf(c);
                        if(index>=0){
                            numericphonenumber.Append(Numbers[index]);
                        }
                    }
                }
            }
            return numericphonenumber.ToString();


        }
    }

}
