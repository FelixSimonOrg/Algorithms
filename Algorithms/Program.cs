//input to sort
int[] unsortedInput = { 10, 5, 7, 2, 4, 8, 3, 1, 9, 6 };
int[] sortedUp = { 10, 9 , 8, 7, 6, 5, 4, 3, 2, 1 };
int[] sortedDown = { 2, 1, 3, 4, 5, 6, 7, 8, 9, 10};
int[] finalSet;
int time = 0;
bool wait = true;

//calls

//finalSet = BubbleSort(sortedUp);
//finalSet = InsertionSort(unsortedInput);

//Input, startIndex, endingIndex
finalSet = QuickSort(unsortedInput, 0, unsortedInput.Length - 1);

string resultString = ResultBuilder(unsortedInput, 0, unsortedInput.Length);
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.WriteLine("\n" + "Sorted Array = " + resultString);
Console.ForegroundColor = ConsoleColor.DarkRed;
Console.ReadKey();

int[] BubbleSort(int[] numbers)
{
    //temp used to switch values
    int temp;

    //loop to replace values in a sorted order, depending on input´s length

    for (int i = 0; i < numbers.Length - 1; i++)
    {
        //loop to iterate over all values to check the if statement, loop size gets smaller depending on the preceded loop 
        for (int j = 0; j < numbers.Length - (1 + i); j++)
        {
            //check if current value is bigger than next value
            if (numbers[j] > numbers[j + 1])
            {
                //temp assigned smaller value
                temp = numbers[j + 1];
                //smaller value gets replaced with bigger value
                numbers[j + 1] = numbers[j];
                //old position from bigger value gets assigned with smaller value
                numbers[j] = temp;
                //loop to build resultString
                string resultString = ResultBuilder(numbers, 0, numbers.Length);
                //return resultString
                Console.WriteLine(resultString + "\n");
                Console.ReadKey();
            }
        }
    }

    return numbers;
}

int[] InsertionSort(int[] numbers)
{
    //loop starts at one, position zero is the already sorted set
    for (int i = 1; i < numbers.Length; i++)
    {
        //get Value were about to sort in
        int valueToSort = numbers[i];
        Console.WriteLine("Value to Sort = " + valueToSort);
        //current position we´re about to insert into the sorted set
        int k = i;
        //moves all elements from the sorted set one position until it found the correct position for the valueToSort
        while (k > 0 && numbers[k - 1] > valueToSort)
        {
            numbers[k] = numbers[k - 1];
            k--;
        }
        Console.WriteLine("Position to insert Value to Sort = " + k + "\n");
        //insert valueToSort into the array with the preceded position k
        numbers[k] = valueToSort;
        //loop to build resultString
        string resultString = ResultBuilder(numbers, 0, numbers.Length);
        //return resultString
        Console.WriteLine(resultString + "\n");
        Console.ReadKey();
    }

    return numbers;
}

int[] QuickSort(int[] numbers, int start, int end)
{
    if (end <= start) return numbers;
    //assign pivotLocation
    int pivot = Partition(numbers, start, end);
    QuickSort(numbers, start, pivot - 1);
    QuickSort(numbers, pivot + 1, end);
    return numbers;
}

int Partition(int[] numbers, int start, int end)
{
    string resultString = ResultBuilder(numbers, start, end + 1);
    Console.WriteLine("Array to handle = " + resultString + "\n");
    if (wait) { Console.ReadKey(); }
    //pivot is always last Index of array
    int pivot = numbers[end];
    Console.WriteLine("Pivot set to: " + pivot + "\n");
    int i = start - 1;
    //iterating through whole array
    for (int j = start; j <= end - 1; j++)
    {
        //if index is smaller than pivot do a swap
        Console.Write("Values to compare: " + numbers[j] + " < " + pivot + "\n");
        Thread.Sleep(time);
        if (numbers[j] < pivot)
        {
            //increment i because all less then incremented i is smaller than our pivot
            i++; 
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Value smaller than pivot, switching positions  " + numbers[i] + " with " + numbers[j] + "\n");
            //temp assigned bigger value
            int temp = numbers[i];
            //smaller value gets assigned to its new index
            numbers[i] = numbers[j];
            //original position from smaller value gets assigned with bigger value
            numbers[j] = temp;
            resultString = ResultBuilder(numbers, start, end + 1);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Changed Array " + resultString + "\n");
            Console.ForegroundColor = ConsoleColor.White;
            if (wait) { Console.ReadKey(); }
        }
        else
        {
            Console.Write("Value bigger than Pivot, position stays the same" + "\n");
            Thread.Sleep(time);
        }
    }
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Switching Pivot to final position at " + (i + 1));

    //increment i one more time to assign pivot to its final position
    i++;
    int tmp = numbers[i];
    numbers[i] = numbers[end];
    numbers[end] = tmp;

    resultString = ResultBuilder(numbers, start, end + 1);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Array with fixed Pivot " + resultString + "\n");
    if (wait) { Console.ReadKey(); }

    //return i as finalPivotPosition
    return i;
}

//string builder for output
string ResultBuilder(int[] input, int start, int end)
{
    string result = "";

    for (int i = start; i < end; i++)
    {
        result = result != "" ? result += " ," : result = "";
        result += input[i];
    }
    return result;
}