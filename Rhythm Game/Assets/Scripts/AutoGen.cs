using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;

namespace Assets.Scripts
{
    internal class AutoGen
    {
        public float _barTime;
        public float _noteTime;
        public float _quantize;
        public float _bpm;

        private void Calculate()
        {
            _barTime = (60 / (_bpm / 4) * 1000);
            _noteTime = _barTime / _quantize;
        }

        private void Update()
        {
            _timer.Update();

            
        }

    }
}
