
static void calculate()
{
  Console.Clear();

  Console.WriteLine("Enter with the first number and press enter");
  var n1 = getNumber();

  Console.WriteLine("");
  var op = getOperator();

  Console.WriteLine("");
  Console.WriteLine("Enter with the second number and press enter");
  var n2 = getNumber();

  var calculateFunction = getCalculateFunction(op);

  var result = calculateFunction(n1, n2);
  Console.WriteLine("");
  Console.WriteLine($"Result: {result}");
}

static float getNumber()
{
  var n = Console.ReadLine();
  var (isAValidNumber, numb) = checkNumberAndReturn(n);

  if (isAValidNumber) return numb;

  return getNumber();

}

static (bool, float) checkNumberAndReturn(string? n)
{
  if (n is null) return (false, 0);

  try
  {
    var numb = float.Parse(n);
    return (true, numb);
  }
  catch
  {
    Console.WriteLine("Invalid number, please enter with a valid number");
    return (false, 0);
  }
}

static string getOperator()
{
  Console.WriteLine("Enter with an operator, example: *, /, +. -");
  var op = Console.ReadLine();
  var isValidOperator = checkOperator(op);

  if (isValidOperator && op != null) return op;

  return getOperator();
}

static bool checkOperator(string? op)
{
  if (op is null) return false;

  var validOperatorsList = new List<string>() { "+", "-", "*", "/" };
  return validOperatorsList.Contains(op);
}

static Func<float, float, float> getCalculateFunction(string op)
{
  switch (op)
  {
    case "*":
      return (numb1, numb2) => numb1 * numb2;
    case "/":
      return (numb1, numb2) => numb1 / numb2;
    case "+":
      return (numb1, numb2) => numb1 + numb2;
    case "-":
      return (numb1, numb2) => numb1 - numb2;
  }

  throw new ArgumentException("Invalid operator");
}

calculate();