using System;
using practice1.Enumerables;

namespace practice1.Entities
{
    internal class Company
    {
        public Guid Id {  get; set; }
        public string Name {  get; set; }
        public DateTime DateOfCreation {  get; set; }
        public string MainActivity {  get; set; }
        public DirectionOfDevelopment directionOfDevelopment {  get; set; }


    }
}
