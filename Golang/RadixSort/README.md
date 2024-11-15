# Radix Sort

**Overview**: Radix Sort is a non-comparison-based sorting algorithm that sorts integers and strings by processing individual digits or characters. It works by grouping numbers based on their individual digits, starting from the least significant digit (LSD) to the most significant digit (MSD). Radix Sort is particularly efficient for sorting fixed-length integers or strings.

## Main Logic

1. **Determine the Maximum Value**:
   - Identify the maximum number in the array to determine the number of digits (or character positions) to sort.

2. **Sorting by Individual Digits**:
   - Use a stable sorting algorithm, such as Counting Sort, to sort the array based on each digit.
   - Start with the least significant digit (LSD) and move towards the most significant digit (MSD).

3. **Repeat for Each Digit**:
   - For each digit position, sort the entire array using Counting Sort. This ensures that digits are processed without rearranging the order of elements that have the same digit (stability).
   - After sorting by the LSD, proceed to the next digit (tens place, hundreds place, etc.) until all digit positions have been processed.

## Example

Let’s sort the array `[170, 45, 75, 90, 802, 24, 2, 66]` using Radix Sort.

1. **Determine the Maximum Value**:
   - The maximum value is `802`, which has three digits.

2. **Sorting by LSD**:
   - **Ones Place**: Sort the array based on the last digit:
     - After counting sort: `[170, 90, 802, 2, 24, 45, 75, 66]`

3. **Sorting by Tens Place**:
   - **Tens Place**: Sort the array based on the second digit:
     - After counting sort: `[170, 802, 2, 24, 45, 75, 66, 90]`

4. **Sorting by Hundreds Place**:
   - **Hundreds Place**: Sort the array based on the first digit:
     - After counting sort: `[2, 24, 45, 66, 75, 90, 170, 802]`

5. **Final Sorted Array**: The final sorted array is `[2, 24, 45, 66, 75, 90, 170, 802]`.

## Time Complexity

- **Best Case**: \(O(n \cdot k)\) (where \(n\) is the number of elements and \(k\) is the number of digits)
- **Average Case**: \(O(n \cdot k)\)
- **Worst Case**: \(O(n \cdot k)\)
- **Space Complexity**: \(O(n + k)\) (for the counting array used in sorting each digit)

## Characteristics

- **Non-Comparison Sort**: Radix Sort does not compare elements directly; it groups numbers by their digits.
- **Stable**: It maintains the relative order of records with equal keys, making it a stable sort.
- **Efficient for Fixed Length**: It performs very well for sorting integers and strings of fixed or limited length, especially when the range of the input data is not significantly larger than the number of elements.
- **Not In-Place**: It requires additional space for the counting array, which can be a drawback for very large datasets.

## Conclusion

Radix Sort is a powerful sorting algorithm that can outperform traditional comparison-based algorithms when dealing with specific types of data, especially integers and fixed-length strings. Its efficiency and stability make it suitable for many applications.
