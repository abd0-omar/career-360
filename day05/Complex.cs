public class Complex(int _real, int _img)
{
    #region Data Fields
    int real = _real;
    int img = _img;
    #endregion
    #region Setters& getters  [Gates]
    public void SetReal(int _real) { real = _real; }
    public void SetImg(int _img) { img = _img; }
    public int GetReal() { return real; }
    public int GetImg() { return img; }

    #endregion
    #region Print
    public string Print()
    {
        if (real == 0 && img == 0)
        {
            return "0";
        }
        else if (real == 0)
        {
            return $"{img}i";
        }
        else if (img == 0)
        {
            return $"{real}";
        }
        else if (img == 1)
        {
            return $"{real}+i";
        }
        else if (img == -1)
        {
            return $"{real}-i";
        }
        // normal case
        else if (img > 0)
        {
            return $"{real}+{img}i";
        }
        else // img < 0
        {
            return $"{real}{img}i";
        }
    }
    #endregion

    #region Function to Add 2 Complex Numbers
    ////caller c1
    //public Complex Add(Complex left,Complex right) 
    //{
    //    Complex result = new Complex();
    //    result.real=left.real+right.real;
    //    result.img=left.img+right.img;
    //    return result;
    //}
    //caller c1
    public Complex Add(Complex right)
    {
        var new_real = /*caller*/real + right.real;
        var new_img = /*caller*/img + right.img;
        return new Complex(new_real, new_img);
    }
    #endregion
}