using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
namespace Service
{
    public class SubjectService
    {
        public List<CodeVO> GetSubjectCode()
        {
            DAC.SubjectDAC dac = new DAC.SubjectDAC();
            return dac.GetSubjectCode();
        }

        public List<SubjectVO> GetSubjectList()
        {
            DAC.SubjectDAC dac = new DAC.SubjectDAC();
            return dac.GetSubjectList();
        }
    }
}
