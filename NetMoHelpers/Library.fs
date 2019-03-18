namespace NetMoHelpers

module Say =
    let hello name =
        printfn "Hello %s" name

module EngTrans =
    let trendEng trendStr =
        trendStr == "stable" ? (string)"Stable" : trendUD trendStr

    let trendUD trendStr =
        trendStr == "up" ? (string)"Grownig" : (string)"Sinking"
