open FSharp.Json
open System.IO

type HttpAuth =
    { ``type``: string
      username: string
      password: string }

type HttpInputs =
    { uri: string
      method: string
      expectedresults: int []
      auth: HttpAuth }

type HttpStep =
    { action: string
      name: string
      inputs: HttpInputs }

type SqlScriptDefinition =
    { name: string
      ``type``: string
      database: string option
      script: string
      ``can-fail``: bool }

type SqlAuth =
    { ``type``: string
      username: string
      password: string }

type SqlInputs =
    { server: string
      auth: SqlAuth
      scripts: SqlScriptDefinition [] }

type SqlStep =
    { action: string
      name: string
      inputs: SqlInputs }

type Step =
    | HttpScript
    | SqlScript

type Document = { name: string; steps: Step [] }

let json = File.ReadAllText("data/example.json")
let deserialized = Json.deserialize<Document> json
printfn "%A" deserialized