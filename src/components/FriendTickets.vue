<template>
  <div  id="FriendTickets">
    <h1 class="h1 mb-1 mt-3 font-weight-normal">{{pageTitle}}</h1>
    <img src="../images/defaultAvatar.svg" alt="Profile icon" height="100px"></img>
    <b-list-group class="justify-content-between align-items-center mt-4">
      <b-list-group-item class="show" button v-for="(ticket,index) in tickets" >
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

    <b-modal id="modallg" size="lg"  centered hide-footer hide-header>
      <img src="../images/logo-primary.svg" class=" " alt="" width="455" height="210" id="logo">

      <div class="pt-3 font-weight-bold">  <h1 class="font-weight-bold">{{tickets[ticketId].EventName}} </h1></div>
      <div> <h2>{{tickets[ticketId].Artist}} </h2></div>
      <div> <h3>Date: {{tickets[ticketId].Date}} </h3></div>
      <div> <h3>Lieu: {{tickets[ticketId].Location}} </h3></div>
      <div> <button class="btn btn-primary" @click="printPDF(ticketId)">Imprimer le billet</button> </div>
      <img src="https://cdn.barcodesinc.com/themes/barcodesinc/images/upc.gif"></img>
    </b-modal>
  </div>
</template>

<script>
    export default {
        name: "FriendTickets",data() {
        return {
          tickets: [
            {
              TicketId:1,
              EventName: 'Show must go on',
              Artist: 'Céline Dion',
              Date:'2019-01-19',
              Location: 'Las Vegas',
              ClientId: 2
            },
            {
              TicketId:1,
              EventName: 'Show must go on',
              Artist: 'Céline Dion',
              Date:'2019-01-19',
              Location: 'Las Vegas',
              ClientId: 2
            },
            {
              TicketId:1,
              EventName: 'Show must go on',
              Artist: 'Céline Dion',
              Date:'2019-01-19',
              Location: 'Las Vegas',
              ClientId: 2
            },
            {
              TicketId:1,
              EventName: 'Show must go on',
              Artist: 'Céline Dion',
              Date:'2019-01-19',
              Location: 'Las Vegas',
              ClientId: 2
            },
            {
              TicketId:1,
              EventName: 'Show must go on',
              Artist: 'Céline Dion',
              Date:'2019-01-19',
              Location: 'Las Vegas',
              ClientId: 2
            },
            {
              TicketId:1,
              EventName: 'Show must go on',
              Artist: 'Céline Dion',
              Date:'2019-01-19',
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
          pageTitle: 'Les billets de:'
        };
        client : { ProfileImage : "../images/defaultAvatar.svg" }

      },

      methods:
        {
          OpenModal(index)
          {
            this.ticketId = index;
          },
          getTickets ()
          {
            var path = 'https://localhost:5001/api/ticket';
            if(this.$route.params.id != undefined)
            {
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
          getDay(date)
          {
            return date.substring(8,10);
          },
          getMonth(date)
          {
            return this.months[ parseInt(date.split("-")[1],10)];
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

          printPDF(ticketId) {
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

        },
      beforeMount(){
        this.getTickets();
        this.getClient();
        if(this.$route.params.id != undefined)
        {
          this.pageTitle = "Billets de 'nom de l'ami'";
        }
      },
    }
</script>

<style scoped>
  #FriendTickets{
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
