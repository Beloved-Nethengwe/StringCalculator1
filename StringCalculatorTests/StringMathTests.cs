using StringCalculator;
using Xunit.Sdk;

namespace StringCalculatorTests
{
    public class StringMathTests
    {
        [Fact]
        public void Step1()
        {
            Assert.Equal(0, StringMath.Add(""));
            Assert.Equal(1, StringMath.Add("1"));
            Assert.Equal(3, StringMath.Add("1,2"));
            Assert.Equal(35, StringMath.Add("5,6,7,8,4,3,2"));
        }

        [Fact]
        public void Step2()
        {
            Assert.Equal(6, StringMath.Add("1\n2,3"));       
            Assert.Equal(32, StringMath.Add("4\n7\n8,9,3\n1"));    
        }

        [Fact]
        public void Step3()
        {
            Assert.Equal(3, StringMath.Add("//;\n1;2"));
            Assert.Equal(11, StringMath.Add("//#\n5#6"));
            Assert.Equal(103, StringMath.Add("//*\n1*2*100"));
        }

        [Fact]
        public void Step4()
        {
            var exception1 = Assert.Throws<Exception>(() => StringMath.Add("//;\n1;-2"));
            Assert.Equal("negatives not allowed -2", exception1.Message);

            var exception2 = Assert.Throws<Exception>(() => StringMath.Add("-1,2,-5,-9"));
            Assert.Equal("negatives not allowed -1,-5,-9", exception2.Message);
            
            var exception3 = Assert.Throws<Exception>(() => StringMath.Add("1\n2,-3"));
            Assert.Equal("negatives not allowed -3", exception3.Message);
        }

        [Fact]
        public void Step5()
        {
            Assert.Equal(3, StringMath.Add("//;\n1;1001;2"));
            Assert.Equal(6, StringMath.Add("1\n2,3,1005"));
            Assert.Equal(103, StringMath.Add("//*\n1*2*100*1089"));
        }

        [Fact]
        public void Step6()
        {
            Assert.Equal(6, StringMath.Add("//[***]\n1***2***3"));
            Assert.Equal(30, StringMath.Add("//[-+-]"));
            Assert.Equal(103, StringMath.Add("//[ABC]\n1ABC2ABC100ABC1089"));
        }
    }
}