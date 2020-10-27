# DOM2JSON 
DOM2JSON  is a my sunday project.It provides to convert all DOM object to JSON.
  - It rendering target site content via chromium. So it can parse SPA(Single Page Application)
  - It parses all objects on the DOM. (Comments, meta e.t.c tags are included.)

#### Tech
DOM2JSON  uses a 2 open source projects to work properly:

* [PuppeterSharp](https://github.com/hardkoded/puppeteer-sharp "PuppeterSharp") - For navigation!
* [HTML Agality Pack](https://github.com/zzzprojects/html-agility-pack "HTML Agality Pack") - For parsing!

### Usage
Like lego science. A simple POST request and JSON response.

##### Request
To: {domain}/api/convert
```json
{
    "target": "TARGET-URL"
}
```
##### Response
```json
{
  "url": "TARGET-URL",
  "elements": [
    {
      "type": "TYPE",
      "innerText": "INNERTEXT",
      "attributes": [
        {
          "name": "ATTRIBUTES-NAME",
          "value": "ATTRIBUTES-VALUE"
        }
      ]
    }
  ]
}
```



License
----
MIT


[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)
