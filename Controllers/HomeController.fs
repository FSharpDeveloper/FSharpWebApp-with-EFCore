﻿namespace FSharpWebApp.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open FSharpWebApp.DataAccessLayer
open FSharpWebApp.Models
open System.Collections.Generic

type HomeController (context: AppDataContext) =
    inherit Controller()
    let mutable _context = context;
    let repo = (new Repository<Group, int>(_context) :> IRepository<Group, int>)
    member this.Index () =
        repo.GetAll
        |> this.View

    member this.About () =
        this.ViewData.["Message"] <- "Your application description page."
        this.View()

    member this.Contact () =
        this.ViewData.["Message"] <- "Your contact page."
        this.View()

    member this.Error () =
        this.View();
