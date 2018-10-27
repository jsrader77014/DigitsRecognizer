using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

namespace DigitsRecognizer
{
    public interface IDistance
    {
        double Between(int[] pixels1, int[] pixels2);
    }
}
