﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

public class GetTranslation
{
    GetAccessToken auth = new GetAccessToken();
    TranslatorService.LanguageServiceClient client = new TranslatorService.LanguageServiceClient();

    // detects the language from the user input
    public void DetectLanguage(string toDetect, DropDownList fromLanguage)
    {
        string appId = auth.GetAccessTokenString();

        string detectedLanguage = client.Detect(appId, toDetect);

        fromLanguage.SelectedValue = detectedLanguage;
    }

    // translates the language from the user input
    public string TranslateLanguage(string userInput, string fromLanguage, string toLanguage)
    {
        string appId = auth.GetAccessTokenString();

        string translatedLanguage = client.Translate(appId, userInput, fromLanguage, toLanguage, "text/plain", "", "");

        return translatedLanguage;
    }
}