IF NOT EXIST bin mkdir bin
%CORPATH%csc /t:library /out:bin\IssueManager.dll /r:System.dll /r:System.Web.dll /r:System.Xml.dll /r:System.Data.dll /optimize+ /recurse:*.cs