using DAC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace Service
{
    public class MGradeService
    {
        public List<MGradeVO> GetMGrade()
        {
            MGradeDAC dac = new MGradeDAC();
            return dac.GetMGrade();
        }
        //public List<MachineVO> GetMachine()
        //{
        //    MachineDAC dac = new MachineDAC();
        //    return dac.GetMachine();
        //}
        //public List<MachineVO> GetMachine()
        //{
        //    MachineDAC dac = new MachineDAC();
        //    return dac.GetMachine();
        //}
        //public List<MachineVO> GetMachine()
        //{
        //    MachineDAC dac = new MachineDAC();
        //    return dac.GetMachine();
        //}
        //public List<MachineVO> GetMachine()
        //{
        //    MachineDAC dac = new MachineDAC();
        //    return dac.GetMachine();
        //}
        //public List<MachineVO> GetMachine()
        //{
        //    MachineDAC dac = new MachineDAC();
        //    return dac.GetMachine();
        //}
    }
}
