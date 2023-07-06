using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathematicalOperationFunctions
{
    public static void CalculateNumbers(this MathematicalOperation operation, out int power, out string equation)
    {
        int num1;
        int num2;
        switch ((MathematicalOperation)Random.Range(0, 4))
        {
            case MathematicalOperation.Add:
                power = Random.Range(2, 10);
                num1 = Random.Range(0, power);
                num2 = power - num1;
                equation = num1 + " + " + num2 + " = ?";
                break;
            case MathematicalOperation.Subtract:
                power = Random.Range(2, 10);
                num1 = Random.Range(power, 100);
                num2 = num1 - power;
                equation = num1 + " - " + num2 + " = ?";
                break;
            case MathematicalOperation.Multiply:
                power = Random.Range(2, 10);
                num1 = Random.Range(1, power / 2);
                num1 -= power % num1;
                num2 = power / num1;
                equation = num1 + " x " + num2 + " = ?";
                break;
            case MathematicalOperation.Divide:
                power = Random.Range(2, 10);
                num1 = Random.Range(power, 100);
                num1 -= num1 % power;
                num2 = num1 / power;
                equation = num1 + " / " + num2 + " = ?";
                break;
            default:
                power = Random.Range(2, 10);
                num1 = Random.Range(0, power);
                num2 = power - num1;
                equation = num1 + " + " + num2 + " = ?";
                break;
        }
    }
}
