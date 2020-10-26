using System;

namespace BACENModel
{
    public class Bank
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Name { get; set; }
        public string ISPB { get; set; }
        public bool Portabilidade { get; set; }
        public bool MaisUsado { get; set; }
        public int Status { get; set; }
        public string Cor { get; set; }
        public DateTime Data { get; set; }
        public bool StatusSTR { get; set; }
        public DateTime DataSTR { get; set; }

        public int StatusPlan { get; set; }
    }
}
