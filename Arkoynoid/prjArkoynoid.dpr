program prjArkoynoid;

uses
  Forms,
  Arkoynoid in 'Arkoynoid.pas' {frmArkoynoid};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TfrmArkoynoid, frmArkoynoid);
  Application.Run;
end.
