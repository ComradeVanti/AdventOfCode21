module AdventOfCode21.SonarSweep1.Sonar

open AdventOfCode21

let analyze (readings: int list, windowSize) =
    readings
    |> List.windowed windowSize
    |> List.map List.sum
    |> List.pairwise
    |> List.countWhere (fun (f, n) -> f < n)
