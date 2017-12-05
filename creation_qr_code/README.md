# Création de QR code
## Quoi à installer?
1. Vous devez avoir python 2.7 sur votre poste de travail. Si vous ne l'avez pas télécharger le à cette addresse: https://www.python.org/downloads/release/python-2713/
. Vous devez par la suite, execcuter le fichier **.exe** installer le tout dans le **C**. Par la suite, vous devez rajouter
deux *PATH* dans vos **variable d'environnement**, soit *C:\Python27* et *C:\Python27\Scripts* . Vous pouvez par la suite tester
dans une console, soit **CMD** ou **Powershell**. Normalement tout fonctionne.

2. Si vous êtes en ligne de commande rendez vous au projet et il faut faire **pip install qrcode**. Si vous êtes sur **Pycharm**
allez dans le terminal et faites la même commande.

## Partir le projet
### Il y a deux méthodes: ligne de commande ou Pycharm
#### Console
- Rentrez dans le répertoire **generator_qr_code**.
- Faites cette instruction *python creator_qr_file.py*.
#### Pycharm
- Faites un clique droit sur le fichier **creator_qr_file.py** et sélectionnez *RUN creator_qr_file.py*.

## Résultats

- Vous devez entrer deux inputs à l'écran. Le premier est le message que vous voulez encrypter dans le QR code et le deuxième est le nom de l'image.
- Vous pouvez voir votre QR code dans le dossier *qr_code*. 
