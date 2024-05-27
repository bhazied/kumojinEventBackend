import { Observable, of } from 'rxjs';

import { EventDto } from '../models/EventDto';
import { EventService } from '../services/event.service';
export class EventMockService extends EventService
{
    override  GetAllEvent(): Observable<any>{
       let data: EventDto[] =  [
            {
              Id: '6622636e-d30d-4be4-8c42-523b90d388a7',
              Name: 'Event for Company : Lubowitz - Carter',
              Description: 'Alias dolorem iste ex.',
              Program:
                'Qui sit illo. Consequatur et quas et nobis dignissimos qui rem. Est debitis sit magni commodi laboriosam. Omnis aut modi quaerat animi eius qui sed.',
              Location: "76618 Zena Motorway, North Rubyeburgh, Cote d'Ivoire",
              TimeZone: 'UTC+02:00',
              StartDate: new Date('2024-06-15T18:36:28'),
              EndDate: new Date('2024-06-16T18:36:28'),
            },
            {
              Id: 'b620607d-25dc-40be-8369-44683a1e72bf',
              Name: 'Event for Company : Leffler, Block and Jast',
              Description: 'Qui sit esse quae nesciunt voluptate ipsum.',
              Program:
                'Porro doloremque quibusdam exercitationem est neque recusandae voluptas dolorum. Sed quae ducimus rerum rem. Voluptatum animi non blanditiis eos et vitae ipsa minus. Eos sit et minus distinctio alias. Necessitatibus numquam eveniet consequatur.',
              Location: '7869 Lempi Viaduct, Port Adonis, New Caledonia',
              TimeZone: 'UTC+04:00',
              StartDate: new Date('2025-02-19T02:29:02'),
              EndDate: new Date('2025-02-21T02:29:02'),
            },
            {
              Id: 'b632cb64-3878-4933-8ed3-b2883cb2e2f8',
              Name: 'Event for Company : Moen LLC',
              Description: 'Maxime a corporis quia eos asperiores voluptatem.',
              Program:
                'Animi sunt et possimus eum sit saepe sit molestiae. Omnis ipsam optio non est et ratione molestias explicabo. Ea ipsum et omnis optio iste. Nam voluptatem qui ut voluptas dolor molestiae optio.',
              Location: '11398 Ferne Mountain, West Krista, Guatemala',
              TimeZone: 'GMT+09:00',
              StartDate: new Date('2025-11-22T22:06:10'),
              EndDate: new Date('2025-11-24T22:06:10'),
            },
          ];
          return of(data);
    }
    
    override  AddEvent(event: EventDto) : Observable<any>{
        return of(1);
    }
}