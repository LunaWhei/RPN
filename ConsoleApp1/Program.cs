

class Rpn
{
    

    public static void Main()
    {
        RPN();
    }

    /// <summary>
    /// RPN FROM NET
    /// </summary>
    private static void RPN()
    {
        char[] breakChars = new char[] { ' ', '\t' };
        for (; ; )
        {
            string inputString = GetInput();

            if (inputString == null) break;
            Stack<string> stack = new Stack<string>
                 (inputString.Split(breakChars, StringSplitOptions.RemoveEmptyEntries));
            if (stack.Count == 0) continue;
            try
            {
                double r = Calc(stack);
                if (stack.Count != 0) throw new Exception();
                Console.WriteLine(r);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
    private static double Calc(Stack<string> stack)
    {
        string poppedElemnt = stack.Pop();
        double x, y;
       
        if (!Double.TryParse(poppedElemnt, out x))
        {
            x = stack.Count > 0 ? Calc(stack) : 0;
            y = stack.Count > 0 ? Calc(stack) : 0;
            
            


            _ = poppedElemnt switch
            {
                ("+") => x += y,
                ("-") => x -= y,
                ("/") => x /= y,
                ("*") => x *= y,
                ("%") => x %= y,

                ("++") => x++,
                ("--") => x--,

                (">") => x = x > y ? 1 : 0,
                ("<") => x = x < y ? 1 : 0,
                ("<=") => x = x <= y ? 1 : 0,
                (">=") => x = x >= y ? 1 : 0,

                ("^") => x = Convert.ToInt32(y) ^ Convert.ToInt32(x),
                ("&") => x = Convert.ToInt32(y) & Convert.ToInt32(x),
                ("|") => x = Convert.ToInt32(y) | Convert.ToInt32(x),
                ("<<") => x = Convert.ToInt32(y) <<  Convert.ToInt32(x),
                (">>") => x = Convert.ToInt32(y) >> Convert.ToInt32(x),
                ("~") => x = ~Convert.ToInt32(x),

                ("cos") => x = Math.Cos(x),
                ("sin") => x = Math.Sin(x),

                ("ceil") => x = Math.Ceiling(x),
                ("floor") => x = Math.Floor(x),
                ("ip") => x = Math.Truncate(x),
                ("fp") => x  = (double)((decimal)x - Math.Truncate((decimal)x)),
                ("sign") => x = Math.Cos(x),
 
                ("abs") => x = Math.Sin(x),
                ("max") => x = Math.Sin(x),
                ("min") => x = Math.Cos(x),





                _ => throw new NotImplementedException()
            };
            
        }
        return x;
    }
    private static string PopElement(Stack<string> stack)
    {
        return stack.Pop();
    }
    private static string GetInput()
    {
       string? S = Console.ReadLine();
        if (S == null)
        {
            return ""; 
        } 
        return S;
    }

    
}