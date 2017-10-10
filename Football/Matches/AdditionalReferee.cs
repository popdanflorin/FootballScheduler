using Football.Interfaces;

namespace Football.Business
{
   public class AdditionalReferee : Person, IAwardSomething
    {
        public string typeName = "additional referee";  //pt ca by default asa va fi, si doar in caz ca e nevoie se va schimba
        public void Interfere(string refOutType)  //additional referee este al 4lea official, care intervine in caz ca unul dintre cei 3 din teren nu mai poate
        {
            typeName = refOutType;
        }

        public string DoSomething()
        {
            return "Stop match";
        }
    }
}
 //ar trebui sa bag si metodele din fieldref si din sideref, in caz ca se va transforma?