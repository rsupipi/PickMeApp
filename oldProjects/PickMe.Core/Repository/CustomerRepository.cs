using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMe.Core.Repository
{
    class CustomerRepository
    {
        public List<String> GetAllRecord()
        {
            List<String> s = new List<String>();
            s.Add("aa");
            s.Add("bb");

            return s;
        }
        
        public String getRecord(){
            return "Supipi";
        }
        
        /*
        public List<HotDog> GetAllHotDogs(){
            IEnumerable<HotDog> hotDogs = 
                from hotDogGroup in hotDogGroups
                from hotDog in hotDogGroup.HotDogs
                
                select hotDog;
                
                return hotDogs hotDogs.ToList<HotDog>();
                
        }
        
        public HotDog GetHotDog ById(int hotDogId){
        
        
        
        
        */


    }
}
