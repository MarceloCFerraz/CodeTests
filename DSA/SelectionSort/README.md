# Selection Sort

**Selection Sort** is a simple, comparison-based sorting algorithm. It works by repeatedly selecting the smallest (or largest) element from an unsorted portion of the array and moving it to the beginning (or end) of the sorted portion.

## How Selection Sort Works

1. **Initial Setup**:
   - Start with an array that needs to be sorted.

2. **Outer Loop**:
   - Iterate through each index of the array. This index represents the boundary between the sorted and unsorted portions of the array.

3. **Finding the Minimum**:
   - For each index, find the minimum element in the unsorted portion of the array.
   - This is done by comparing each element in the unsorted portion to find the smallest one.

4. **Swapping**:
   - Once the minimum element is found, swap it with the element at the current index (the boundary of the sorted portion).
   - This effectively grows the sorted portion of the array by one element.

5. **Repeat**:
   - Continue the process until the entire array is sorted.

## Example of Selection Sort

Let's sort the array `[64, 25, 12, 22, 11]` using Selection Sort.

1. **Pass 1**:
   - Find the minimum in `[64, 25, 12, 22, 11]` → Minimum is `11`.
   - Swap `11` with `64` → Result: `[11, 25, 12, 22, 64]`.

2. **Pass 2**:
   - Find the minimum in `[25, 12, 22, 64]` → Minimum is `12`.
   - Swap `12` with `25` → Result: `[11, 12, 25, 22, 64]`.

3. **Pass 3**:
   - Find the minimum in `[25, 22, 64]` → Minimum is `22`.
   - Swap `22` with `25` → Result: `[11, 12, 22, 25, 64]`.

4. **Pass 4**:
   - Find the minimum in `[25, 64]` → Minimum is `25`.
   - No swap needed → Result: `[11, 12, 22, 25, 64]`.

5. **Pass 5**:
   - Only one element left, so it is already sorted.

## Time Complexity

- **Best Case**: \(O(n^2)\)
- **Average Case**: \(O(n^2)\)
- **Worst Case**: \(O(n^2)\)

Selection Sort always performs \(O(n^2)\) comparisons regardless of the initial order of elements because it always scans the remaining unsorted elements to find the minimum.

## Space Complexity

- **Space Complexity**: \(O(1)\)
- Selection Sort is an in-place sorting algorithm, meaning it does not require additional storage proportional to the size of the input array.

## Characteristics

- **Stable**: Selection Sort is not a stable sorting algorithm. Equal elements may not retain their original relative order.
- **Simple to Implement**: Its straightforward approach makes it easy to understand and implement.
- **Inefficient for Large Data**: Due to its \(O(n^2)\) time complexity, it is not suitable for large datasets.

## Conclusion

Selection Sort is an easy-to-understand algorithm that is more educational than practical for large datasets. Its simplicity and in-place nature make it useful for small arrays or as a teaching tool for understanding basic sorting concepts.
