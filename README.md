# BracketsRemoval

This repository contains my solution for external brackets removal. The main code (containing the core logic) can be found inside `BracketsRemoval` project, while `BracketsRemoval.WebAPI` just exposes this functionality via HTTP.

# Usage

## Swagger (debug)

Once this repository is cloned on your pc and you start a new debugging instance, a swagger page is immediately opened in your browser, through which you can easily invoke the API.

As an alternative, you can call the API through any client using the structures defined in the [next chapters](#Data-structure).

## Docker

This solution is released as docker image on docker hub. To install it, run the following commands:

```
docker pull maradev21/bracketsremoval
docker run -p [yourPort]:5000 maradev21/bracketsremoval
```

# Data structure

## Request

```json
{
  "dirtyText": "(((your text with brackets)))",
  "timestamp": "2022-07-04T12:00:000"
}
```

## Response

```json
{
  "request": {
    "dirtyText": "(((your text with brackets)))",
    "timestamp": "2022-07-04T12:00:000"
  },
  "cleanText": "your text with brackets",
  "errorMessage": "",
  "timestamp": "2022-07-04T12:00:00.500Z"
}
```

```json
{
  "request": {
    "dirtyText": "(((your text with pathological brackets))(((",
    "timestamp": "2022-07-04T12:00:000"
  },
  "cleanText": "",
  "errorMessage": "The passed text is pathological: not all brackets are correctly opened or closed.",
  "timestamp": "2022-07-04T12:00:00.500Z"
}
```
