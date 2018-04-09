let square x = x * x

let sumOfSquares n =
    [0..n] |> List.map square |> List.sum

sumOfSquares 0 // 0 * 0 = 0
sumOfSquares 1 // 0 + (1 * 1) = 1
sumOfSquares 2 // 1 + (2 * 2) = 5
sumOfSquares 3 // 5 + (3 * 3) = 14  