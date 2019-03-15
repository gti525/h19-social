<template>
    <div  id="tickets">
      <h1 class="h1 mb-1 mt-3 font-weight-normal">{{pageTitle}}</h1>
      <img src="../images/defaultAvatar.svg" alt="Profile icon" height="100px"></img>
          <b-list-group class="justify-content-between align-items-center mt-4">
            <b-list-group-item class="show" button v-for="(ticket,index) in tickets" v-b-modal.modallg v-on:click="OpenModal(index)">
              <div class="show-date ">
                <div class="day"> {{ getDay(ticket.Date) }}</div>
                <div class="month">{{ getMonth(ticket.Date) }}</div>
              </div>
              <div class="show-info">
                <div class="show-name">
                  {{ ticket.EventName }}
                </div>
              </div>
            </b-list-group-item>
          </b-list-group>

      <b-modal id="modallg" size="lg" centered hide-footer hide-header>
        <img src="../images/logo-primary.svg" class=" " alt="" width="455" height="210" id="logo">
        <div class="pt-3 font-weight-bold">  <h1 class="font-weight-bold">{{tickets[ticketId].EventName}} </h1></div>
            <div> <h2>{{tickets[ticketId].Artist}} </h2></div>
            <div> <h3>Date: {{tickets[ticketId].Date}} </h3></div>
            <div> <h3>Lieu: {{tickets[ticketId].Location}} </h3></div>
            <div> <button class="btn btn-primary" @click="printPDF(ticketId, tickets[ticketId].EventName, tickets[ticketId].Artist, tickets[ticketId].Date, tickets[ticketId].Location)">Imprimer le billet</button> </div>
            <canvas id="canvas"></canvas>
      </b-modal>
    </div>
</template>

<script>
  import * as jsPDF from 'jspdf'
  import QRCode from 'qrcode'

  export default {
    name: "Tickets",

    data() {
      return {
        tickets: [
          {
            TicketId: 1,
            EventName: 'Show must go on',
            Artist: 'Céline Dion',
            Date: '2019-01-19',
            Location: 'Las Vegas',
            ClientId: 2
          },
          {
            TicketId: 1,
            EventName: 'Show must go on',
            Artist: 'Céline Dion',
            Date: '2019-01-19',
            Location: 'Las Vegas',
            ClientId: 2
          },
          {
            TicketId: 1,
            EventName: 'Show must go on',
            Artist: 'Céline Dion',
            Date: '2019-01-19',
            Location: 'Las Vegas',
            ClientId: 2
          },
          {
            TicketId: 1,
            EventName: 'Show must go on',
            Artist: 'Céline Dion',
            Date: '2019-01-19',
            Location: 'Las Vegas',
            ClientId: 2
          },
          {
            TicketId: 1,
            EventName: 'Show must go on',
            Artist: 'Céline Dion',
            Date: '2019-01-19',
            Location: 'Las Vegas',
            ClientId: 2
          },
          {
            TicketId: 1,
            EventName: 'Show must go on',
            Artist: 'Céline Dion',
            Date: '2019-01-19',
            Location: 'Las Vegas',
            ClientId: 2
          },
        ],
        months: {
          1: "JAN",
          2: "FÉV",
          3: "MAR",
          4: "AVR",
          5: "MAI",
          6: "JUN",
          7: "JUL",
          8: "AOÛ",
          9: "SEP",
          10: "OCT",
          11: "NOV",
          12: "DÉC",
        },
        ticketId: 0,
        barcodeValue: '123445435',
        pageTitle: 'Mes Billets'
      };
      client : {
        ProfileImage : "../images/defaultAvatar.svg"
      }

    },

    methods:
      {
        OpenModal(index) {
          this.ticketId = index;
          var canvas = document.getElementById('canvas')

          QRCode.toCanvas(canvas, this.ticketId.toString(), function (error) {
            if (error) console.error(error)
          })
        },
        getTickets() {
          var path = 'https://localhost:5001/api/ticket';
          if (this.$route.params.id != undefined) {
            path + '/this.$route.params.id';
          }

          this.$http.get(path, {
              headers: {
                Authorization: "Bearer " + localStorage.getItem("token")
              }
            }
          ).then(response => {

            this.tickets = response.data;

          }, response => {
            // error callback
            console.log(response);
          });
        },
        getDay(date) {
          console.alert
          return date.substring(8, 10);
        },
        getMonth(date) {
          return this.months[parseInt(date.split("-")[1], 10)];
        },

        getClient() {
          this.$http.get('https://localhost:5001/api/client', {
            headers: {
              Authorization: "Bearer " + localStorage.getItem("token")
            }
          }).then(response => {
            this.client = response.data;
          }, response => {
            // error callback
            console.log(response);
          });
        },

        printPDF: function (ticketId, eventName, artist, date, location) {

          var imgData = 'data:image/jpeg;base64,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'

          var opts = {
            errorCorrectionLevel: 'H',
            type: 'image/jpeg',
            rendererOpts: {
              quality: 1
            }
          }
          var src
          QRCode.toDataURL('text', opts, function (err, url) {
            if (err) throw err

            src = url
          })

          var doc = new jsPDF({
            orientation: 'landscape',
            unit: 'mm',
            format: [535,130]
          })

          doc.addImage(imgData, 'JPEG', 5, 0, 45, 45)

          doc.setTextColor(138,43,226)
          doc.setFontSize(12)
          doc.text('Événement : ' + eventName + ' //', 55, 15)
          doc.text(artist, 80, 20)
          doc.text('Numéro de billet : ' + ticketId, 55, 28)
          doc.text('Le ' + date + ' situé ' + location, 55, 38)

          doc.addImage(src, 'JPEG', 138, -5, 55, 55)

          doc.save('billet.pdf')

          /*
            this.$http.get('https://localhost:5001/api/ticket/' + ticketId+1 + '/printPDF', {
              headers: {
                Authorization: "Bearer " + localStorage.getItem("token")
              }
            }).then(response => {
              console.log('Print PDF worked')
            }, response => {
              console.log('Print PDF has failed')
            });
          }
          */

        },

        },
    beforeMount() {
      alert("Bienvenue");
      this.getTickets();
      this.getClient();
      if (this.$route.params.id != undefined) {
        this.pageTitle = "Billets de 'nom de l'ami'";
      }
      }
  }
</script>

<style scoped>

  #tickets{
    width:800px;
    margin:auto;
    left:50%;
  }

  .show{
    height: 150px;
    width: 800px;
    padding: 0px;
    margin-bottom: 20px;
    z-index: 0;
  }
  .show-date{
    width: 20%;
    height: 100%;
    float: left;
  }

  .day{
    margin:0;
    position:relative;
    height: 70%;
    color: black;
    font-size: 70px;
  }

  .month{
    top: 70%;
    font-size: 30px;
    font-weight: bold;
  }

  .show-info{
    width:80%;
    float: right;
    height:100%;
  }

  .show-name{
    font-size: 50px;
    position: relative;
    top:25%;
  }

  .day, .month{
	color: #495057;
  }

  .show-date{
	border-style: solid;
	border-width: 0px 2px 0px 0px;
	border-color: var(--primary-color);

  }

  .show-info {
	background-color: white;
   }

   .list-group-item:hover .show-date {
	background-color: var(--secondary-color);
   }

   .list-group-item:hover .show-info{
     background-color: var(--secondary-color);

   }

   .list-group-item {
		border-style: solid;
		border-width: 2px;
		border-color: #a133f8;
	}

	.h1 {
	color: #495057;
    left:0;
  }


</style>
