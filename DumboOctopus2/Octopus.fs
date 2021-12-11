module AdventOfCode21.DumboOctopus2.Octopus


type EnergyLevel = int

type Octopus = { EnergyLevel: EnergyLevel }


let makeOctopus energyLevel = { EnergyLevel = energyLevel }

let energyLevel octopus = octopus.EnergyLevel

let willFlash octopus = octopus |> energyLevel > 9

let hasFlashed octopus = octopus |> energyLevel = 0

let withEnergyLevel e octopus = { octopus with EnergyLevel = e }

let buildEnergy octopus =
    octopus |> withEnergyLevel ((octopus |> energyLevel) + 1)

let flash octopus = octopus |> withEnergyLevel 0
